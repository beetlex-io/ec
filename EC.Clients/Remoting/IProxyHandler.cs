using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Remoting
{
    public interface IProxyHandler
    {

        Beetle.Express.IData LastRemotingData
        {
            get;
            set;
        }
        Result Execute(RemoteInvokeArgs info);
    }
}
