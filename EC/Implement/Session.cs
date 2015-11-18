using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Implement
{
    public class Session:ISession
    {
        public Beetle.Express.IChannel Channel
        {
            internal set;
            get;
        }

        public IApplication Application
        {
            get;
            internal set;
        }

        public object this[string key]
        {
            get
            {
                return Channel[key];
            }
            set
            {
                Channel[key] = value;
            }
        }

        [ThreadStatic]
        private static ISession mSession;

        public static ISession Current
        {
            get
            {
                return mSession;
            }
            set
            {
                mSession = value;
            }
        }

        public void Dispose()
        {
            Channel = null;
            Application = null;
        }
    }
}
