using EC.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EC.Remoting
{
    public class MessageCenter : IMessageCenter
    {
        public void Init(IApplication application)
        {
            mApplication = (Implement.Application)application;
            TypeMapper = Utils.GetMessageMapping();
            Controllers = new List<object>();
            LoadSoa(application);
            LoadController(application);
        }

        private Implement.Application mApplication;


        private const string SOA_INVOKE_TAG = "__SOA";

        private Dictionary<string, IMethodHandler> mSoaHandlers = new Dictionary<string, IMethodHandler>(1024);

        private Dictionary<Type, IMethodHandler> mControllerHandlers = new Dictionary<Type, IMethodHandler>(1024);

        internal TypeMapper TypeMapper
        {
            get;
            set;
        }

        private void LoadController(IApplication application)
        {
            Utils.LoadAssembly(a =>
            {
                foreach (Type type in a.GetTypes())
                {
                    if (IKende.IKendeCore.GetTypeAttributes<ControllerAttribute>(type, false).Length > 0 && !type.IsAbstract)
                    {
                        "load {0} controller".Log4Info(type);
                        object controller = Activator.CreateInstance(type);
                        Controllers.Add(controller);
                        foreach (System.Reflection.MethodInfo method in type.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                        {
                            try
                            {
                                ParameterInfo[] pis = method.GetParameters();
                                if (pis.Length == 2 && (pis[0].ParameterType == typeof(ISession)))
                                {
                                    IMethodHandler handler = new MethodHandler(controller, method, application);
                                    mControllerHandlers[pis[1].ParameterType] = handler;
                                    "load {0}->{1} action success".Log4Info(type, method.Name);
                                }

                            }
                            catch (Exception e_)
                            {
                                "load {0}->{1} action error".Log4Error(e_, type, method.Name);
                            }
                        }


                    }
                }
            });
        }

        private void LoadSoa(IApplication application)
        {
            Utils.LoadAssembly(a =>
            {
                foreach (Type type in a.GetTypes())
                {

                    SOAServiceAttribute[] soa = IKende.IKendeCore.GetTypeAttributes<SOAServiceAttribute>(type, false);
                    if (soa.Length > 0 && !type.IsAbstract)
                    {
                        foreach (Type itype in soa[0].Services)
                        {
                            if (itype.IsInterface)
                            {
                                object service = Activator.CreateInstance(type);
                                foreach (MethodInfo method in itype.GetMembers())
                                {
                                    StringBuilder key = new StringBuilder();
                                    List<Type> pst = new List<Type>();
                                    key.Append(itype.Name).Append(".").Append(method.Name);
                                    key.Append("(");
                                    ParameterInfo[] pis = method.GetParameters();
                                    for (int i = 0; i < pis.Length; i++)
                                    {
                                        pst.Add(pis[i].ParameterType);
                                        if (i > 0)
                                            key.Append(",");
                                        key.Append(pis[i].ParameterType.Name);
                                    }
                                    key.Append(")");
                                    MethodInfo implMethod = service.GetType().GetMethod(method.Name, pst.ToArray());
                                    if (implMethod != null)
                                    {
                                        MethodHandler handler = new MethodHandler(service, implMethod, mApplication);
                                        handler.Parameters = implMethod.GetParameters();
                                        mSoaHandlers[key.ToString()] = handler;
                                    }
                                    "Load SOA Service {0}".Log4Info(key);
                                }
                            }
                        }
                    }
                }
            });
        }

        public byte[] GetMessageTypeData(Type type)
        {
            short typevalue = TypeMapper.GetValue(type);
            if (typevalue == 0)
                "{0} type value not registed".ThrowError<Exception>(type);
            byte[] typedata = BitConverter.GetBytes(typevalue);
            return typedata;

        }

        public Type GetMessageType(System.IO.Stream stream)
        {
            byte[] typedata = new byte[2];
            stream.Read(typedata, 0, 2);
            short typevalue = BitConverter.ToInt16(typedata, 0);
            Type type = TypeMapper.GetType(typevalue);
            if (type == null)
                "{0} value type notfound".ThrowError<Exception>(typevalue);
            return type;
        }

        public void ProcessMessage(object message, ISession context)
        {
            Events.EventMessageProcessArgs mpa = new Events.EventMessageProcessArgs();
            mpa.Application = this.mApplication;
            mpa.Cancel = false;
            mpa.Session = context;
            mpa.Message = message;
            OnMessageExecting(mpa);
            if (mpa.Cancel)
                return;
            IMethodHandler handler = null;
            RemoteInvokeArgs invokeArgs = (RemoteInvokeArgs)context[SOA_INVOKE_TAG];
            if (message is RPC.MethodCall)
            {
                invokeArgs = new RemoteInvokeArgs((RPC.MethodCall)message);
                context[SOA_INVOKE_TAG] = invokeArgs;
            }
            else
            {
                if (invokeArgs == null)
                {
                    if (mControllerHandlers.TryGetValue(message.GetType(), out handler))
                    {

                        object data = new object[] { handler, context, message };
                        if (handler.UseThreadPool)
                        {
                            System.Threading.ThreadPool.QueueUserWorkItem(OnControllerProcess, data);
                        }
                        else
                        {
                            OnControllerProcess(data);
                        }

                    }
                    else
                    {
                        "{0} messgae action notfound".Log4Error(message.GetType());
                    }
                    return;
                }
                else
                {
                    invokeArgs.AddParameter(message);
                }
            }
            if (invokeArgs.HasCompleted)
            {
                context[SOA_INVOKE_TAG] = null;
                string key = invokeArgs.GetKey();
                if (mSoaHandlers.TryGetValue(key, out handler))
                {

                    object data = new object[] { handler, context, invokeArgs.Parameters, invokeArgs };
                    if (handler.UseThreadPool)
                    {
                        System.Threading.ThreadPool.QueueUserWorkItem(OnSOAProcess, data);
                    }
                    else
                    {
                        OnSOAProcess(data);
                    }
                }
                else
                {
                    RPC.MethodResult result = new RPC.MethodResult();
                    result.Status = ResultStatus.Error;
                    result.Error = string.Format("{0} method not found!", key);
                    mApplication.Server.Send(result, context.Channel);
                    "{0} method notfound".Log4Error(key);
                }
            }


        }

        private void OnSOAProcess(object data)
        {
            object[] array = (object[])data;
            IMethodHandler handler = (IMethodHandler)array[0];
            ISession context = (ISession)array[1];
            object[] message = (object[])array[2];
            RemoteInvokeArgs riargs = (RemoteInvokeArgs)array[3];
            RPC.MethodResult result = new RPC.MethodResult();
            result.ID = riargs.CallID;
            Implement.Session.Current = context;
            result.Status = ResultStatus.Success;
            MethodContext mc;
            object rdata = null;
            IList<Message> returnValues = new List<Message>();
            returnValues.Add(new Message(result, typeof(RPC.MethodResult)));
            IList<string> refParameters = null;
            try
            {

                mc = new MethodContext(mApplication, context, message, handler);
                mc.Execute();
                rdata = mc.Result;
                result.IsVoid = handler.Info.ReturnType == typeof(void);
                if (!result.IsVoid)
                    returnValues.Add(new Message(rdata, handler.Info.ReturnType));
                if (handler.Parameters.Length > 0)
                {
                    result.Parameters = new string[handler.Parameters.Length];
                    for (int i = 0; i < handler.Parameters.Length; i++)
                    {
                        System.Reflection.ParameterInfo pi = handler.Parameters[i];
                        if (pi.IsOut || pi.IsRetval)
                        {
                            if (refParameters == null)
                            {
                                refParameters = new List<string>();

                            }
                            Type ptype = pi.ParameterType;
                            returnValues.Add(new Message(message[i], ptype.Name.IndexOf('&') ==-1 ? ptype : ptype.GetElementType()));
                            refParameters.Add(pi.Name);
                        }
                    }
                    if (refParameters != null)
                        result.Parameters = refParameters.ToArray();
                }

            }
            catch (Exception e_)
            {
                result.Status = ResultStatus.Error;
                result.Error = e_.Message;
                "{0} invoke error ".Log4Error(e_, handler.ToString());
                context.Channel.InvokeError(e_);
            }
            finally
            {
                Implement.Session.Current = null;
            }
            try
            {
                Beetle.Express.IData sdata = ((IPacketAnalyzer)context.Channel.Package).GetMessageData(returnValues);
                context.Application.Server.Send(sdata, context.Channel);
            }
            catch (Exception e__)
            {
                "{0} get return data error ".Log4Error(e__, handler.ToString());
                context.Channel.InvokeError(e__);
            }

        }

        private void OnControllerProcess(object data)
        {
            object[] array = (object[])data;
            IMethodHandler handler = (IMethodHandler)array[0];
            ISession context = (ISession)array[1];
            object message = array[2];
            Implement.Session.Current = context;
            try
            {

                MethodContext mc = new MethodContext(mApplication, context, new object[] { context, message }, handler);

                mc.Execute();
                if (mc.Result != null)
                    mApplication.Server.Send(mc.Result, context.Channel);
            }
            catch (Exception e_)
            {
                "{0} invoke error ".Log4Error(e_, handler.ToString());
                context.Channel.InvokeError(e_);
            }
            finally
            {
                Implement.Session.Current = null;
            }

        }

        public string Name
        {
            get { return "Remoting Message Center"; }
        }

        public IList<object> Controllers
        {
            get;
            private set;
        }
        private void OnMessageExecting(Events.EventMessageProcessArgs e)
        {
            if (MessageExecting != null)
            {
                MessageExecting(this, e);
            }
        }

        public event EventHandler<Events.EventMessageProcessArgs> MessageExecting;
    }
}
