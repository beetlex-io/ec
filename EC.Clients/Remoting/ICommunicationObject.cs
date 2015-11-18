using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EC.Clients;

namespace EC.Remoting
{
    public interface ICommunicationObject
    {
        IClient Client { get; set; }
       /* bool Send(object message);

        Beetle.Express.EventPackageReceive Receive
        {
            get;
            set;
        }

        Beetle.Express.Clients.TcpClient Connection
        {
            get;
        }

        void RegisterRemote(long id, MethodReturnArgs e);

        void UnRegisterRemote(long id);

        MethodReturnArgs Pop();

        void Push(MethodReturnArgs args);*/
    }
}
