using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace EC.Implement
{
    class DefaultMessageCenter : IMessageCenter
    {
        public void Init(IApplication application)
        {
            mApplication = (Implement.Application)application;
            TypeMapper = Utils.GetMessageMapping();
            Controllers = new List<object>();
            LoadController(application);
        }

        private Implement.Application mApplication;

        private Dictionary<Type, IMethodHandler> mHandlers = new Dictionary<Type, IMethodHandler>(1024);

        public TypeMapper TypeMapper
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
                                    mHandlers[pis[1].ParameterType] = handler;
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
            if (mHandlers.TryGetValue(message.GetType(), out handler))
            {
                
                object data = new object[] { handler,context,message};
                if (handler.UseThreadPool)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(OnProcessMessage, data);
                }
                else
                {
                    OnProcessMessage(data);
                }
            }
            else
            {
                "{0} messgae action notfound".Log4Error(message.GetType());
            }

        }

        private void OnProcessMessage(object data)
        {
            object[] array = (object[])data;
            IMethodHandler handler = (IMethodHandler)array[0];
            ISession context = (ISession)array[1];
            object message = array[2];
            Session.Current = context;
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
                Session.Current = null;
            }
        }



        public string Name
        {
            get { return "Default Message Center"; }
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
