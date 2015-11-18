using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Implement
{
    class MethodContext:IMethodContext
    {
        public MethodContext(IApplication app, ISession session, object[] parameters, IMethodHandler handler)
        {
            Application = app;
            Session = session;
            Parameters = parameters;
            Handler = handler;
        }
        private int mIndex = 0;

        private bool mFirstInvoke = true;

        public IApplication Application
        {
            get;
            internal set;
        }

        public ISession Session
        {
            get;
            internal set;
        }

        public object[] Parameters
        {
            get;
            internal set;
        }
      
        public void Execute()
        {
            if (mFirstInvoke)
            {
                mFirstInvoke = false;
                ((Implement.Application)Application).OnMethodProcess(new Events.EventMethodProcessArgs { Session=Session, Application= Application, Method=this });
               
            }
            FilterAttribute[] filters = Handler.Filters;
            if (filters == null || filters.Length ==0 || mIndex >= filters.Length)
            {
                Result = Handler.Execute(this, Parameters);
            }
            else
            {
                FilterAttribute filter = filters[mIndex];
                mIndex++;
                filter.Execute(this);
            }
        }

        public IMethodHandler Handler
        {
            get;
            internal set;
        }

        public object Result
        {
            get;
            set;
        }
    }
}
