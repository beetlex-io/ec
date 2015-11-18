using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC
{
    public interface IMethodContext
    {
        IApplication Application
        {
            get;
        }

        ISession Session { get; }

        object[] Parameters { get; }

        void Execute();

        IMethodHandler Handler { get; }

        object Result { get; set; }
    }
}
