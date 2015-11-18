using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beetle.Express;

namespace EC
{
    public interface ISession:IDisposable
    {
        IChannel Channel
        {
            get;
        }

        IApplication Application
        {
            get;
        }

        object this[string key]
        {
            get;
            set;
        }

        
    }
}
