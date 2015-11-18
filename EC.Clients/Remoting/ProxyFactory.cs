using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Remoting
{
    public class ProxyFactory
    {

        static ProxyFactory()
        {
            CursorFactory = new ProxyFactory();
            CursorFactory.Handler = new ECProxyHandler();

        }

        private Dictionary<Type, ProxyBuilder> mBuilders = new Dictionary<Type, ProxyBuilder>();

        public static ProxyFactory CursorFactory
        {
            get;
            private set;
        }

        public IProxyHandler Handler { get; set; }

        public Result Execute(ICommunicationObject client, string service, System.Reflection.MethodBase method, params object[] data)
        {


            RemoteInvokeArgs info = new RemoteInvokeArgs();
            info.Interface = service;
            info.Method = method.Name;
            info.Parameters = data;
            info.CommunicationObject = client;
            info.ParameterInfos = method.GetParameters();
            foreach (System.Reflection.ParameterInfo pi in method.GetParameters())
            {
                info.ParameterTypes.Add(pi.ParameterType.Name);
            }
            return Handler.Execute(info);

        }

        public object CreateInstance(Type type)
        {
            ProxyBuilder builder = null;
            if (!type.IsInterface)
                throw new ProxyException(string.Format("{0} is not a interface!", type.Name));
            lock (mBuilders)
            {
                if (!mBuilders.TryGetValue(type, out builder))
                {
                    builder = new ProxyBuilder(type);
                }
            }
            return builder.CreateInstance();
        }

        public T CreateInstance<T>()
        {
            return (T)CreateInstance(typeof(T));
        }
    }
}
