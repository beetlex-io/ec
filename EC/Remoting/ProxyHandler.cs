using EC.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EC.Remoting
{
    class ProxyHandler
    {

        private Dictionary<string, MethodHandler> mHandlers = new Dictionary<string, MethodHandler>();

        public void Register(object service)
        {
            SOAServiceAttribute[] soa = (SOAServiceAttribute[])service.GetType().GetCustomAttributes(typeof(SOAServiceAttribute), false);
            Register(service, soa);
        }

        private void Register(object service, SOAServiceAttribute[] soa)
        {
            if (soa.Length > 0)
            {
                foreach (Type itype in soa[0].Services)
                {
                    if (itype.IsInterface)
                    {
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
                                MethodHandler handler = new MethodHandler { Obj = service, Method = implMethod, Parameters = pis };
                                mHandlers[key.ToString()] = handler;
                            }

                        }
                    }
                }
            }
        }

        public void Register(Type service)
        {
            Register(Activator.CreateInstance(service));
        }

        public Result Execute(RemoteInvokeArgs info)
        {
            Result result = new Result();
            result.Status = ResultStatus.Success;
            MethodHandler handler;
            if(mHandlers.TryGetValue(info.GetKey(),out handler))
            {
                try
                {

                    result.Data = handler.Execute(info.Parameters);
                    if (handler.Parameters != null && handler.Parameters.Length > 0)
                    {
                        for (int i = 0; i < handler.Parameters.Length; i++)
                        {
                            if (handler.Parameters[i].IsRetval || handler.Parameters[i].IsOut)
                            {
                                result[handler.Parameters[i].Name] = info.Parameters[i];
                            }
                        }
                    }
                }
                catch(Exception e_)
                {
                     result.Status = ResultStatus.Error;
                     result.Error = string.Format("{0} method invoke error {1}!\r\nStackTrace:{2}", info.GetKey(), e_.Message, e_.StackTrace);
                }
            }
            else{
                result.Status = ResultStatus.Error;
                result.Error = string.Format("{0} method handler not found!", info.GetKey());
               
            }
            return result;
        }
    }
}
