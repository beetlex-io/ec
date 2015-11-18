using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Implement
{
    class MethodHandler : IMethodHandler
    {
        public MethodHandler(object controller, System.Reflection.MethodInfo method, IApplication application)
        {
            mHandler = new IKende.MethodHandler(method);
            Info = method;
            Controller = controller;
            LoadFilter(controller, method, application);
            UseThreadPool = IKende.IKendeCore.GetMethodAttributes<EC.ThreadPoolAttribute>(method, false).Length > 0;
        }

        private void LoadFilter(object controller, System.Reflection.MethodInfo method, IApplication application)
        {
            List<FilterAttribute> filters = new List<FilterAttribute>();
            List<Type> skipTypes = new List<Type>();
            List<FilterAttribute> successFilters = new List<FilterAttribute>();
            foreach (FilterAttribute item in application.Filters)
            {
                filters.Add(item);
            }
            foreach (FilterAttribute item in IKende.IKendeCore.GetTypeAttributes<FilterAttribute>(controller.GetType(), false))
            {
                filters.Add(item);
            }
            foreach (FilterAttribute item in IKende.IKendeCore.GetMethodAttributes<FilterAttribute>(method, false))
            {
                filters.Add(item);
            }
            foreach (SkipFilterAttribute item in IKende.IKendeCore.GetTypeAttributes<SkipFilterAttribute>(controller.GetType(), false))
            {
                foreach (Type type in item.Types)
                {
                    skipTypes.Add(type);
                }
            }
            foreach (SkipFilterAttribute item in IKende.IKendeCore.GetMethodAttributes<SkipFilterAttribute>(method, false))
            {
                foreach (Type type in item.Types)
                {
                    skipTypes.Add(type);
                }
            }
            foreach (FilterAttribute item in filters)
            {
                if (!skipTypes.Contains(item.GetType()))
                {
                    successFilters.Add(item);
                }
            }
            Filters = successFilters.ToArray();
        }

        private IKende.MethodHandler mHandler;

      

        public object Execute(IMethodContext context, object[] parameters)
        {
            return mHandler.Execute(Controller, parameters);
        }

        public FilterAttribute[] Filters
        {
            get;
            internal set;
        }

        public override string ToString()
        {
            return string.Format("{0}->{1}", Controller.GetType(), mHandler.Info.Name);
        }


        public bool UseThreadPool
        {
            get;
            private set;
        }


        public object Controller
        {
            get;
            private set;
        }
        public System.Reflection.ParameterInfo[] Parameters
        {
            get;
            set;
        }
        public System.Reflection.MethodInfo Info
        {
            get;
            private set;
        }
    }
}
