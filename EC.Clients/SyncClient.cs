using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using EC.Clients;
namespace EC
{
    public class ProtoSyncClient : SyncClient<ProtobufPacket>
    {
        public ProtoSyncClient(string host, int port = 10034)
            : base(host, port)
        {

        }
    }
    public class ProtoClient : Client<ProtobufPacket>
    {
        public ProtoClient(string host, int port = 10034)
            : base(host, port)
        {

        }
    }
    public class MsgPackClient : Client<MsgPackPacket>
    {
        public MsgPackClient(string host, int port = 10034)
            : base(host, port)
        {

        }
    }
    public class MsgPackSyncClient : SyncClient<MsgPackPacket>
    {
        public MsgPackSyncClient(string host, int port = 10034)
            : base(host, port)
        {

        }
    }
}
namespace EC.Clients
{
    public interface ISyncClient
    {
        int TimeOut
        {
            get;
            set;
        }
        object Send(object message, bool sendOnly = false);

        object Read();

        Beetle.Express.Clients.SyncTcpClient Connection
        {
            get;
        }
       
    }
    public class SyncClient<T>:ISyncClient where T : Beetle.Express.IPackage, new()
    {
        public SyncClient(string host, int port = 10034)
        {

            mConnection = new Beetle.Express.Clients.SyncTcpClient(host, port, new T());

        }

        public int TimeOut
        {
            get
            {
                return mConnection.TimeOut;
            }
            set
            {
                mConnection.TimeOut = value;
            }
        }

        private Beetle.Express.Clients.SyncTcpClient mConnection;

        public object Send(object message, bool sendOnly = false)
        {
            if (sendOnly)
            {
                mConnection.SendMessageOnly(message);
                return null;
            }
            return mConnection.SendMessage(message);
        }

        public RESULT Send<RESULT>(object message, bool sendOnly = false)
        {
            return (RESULT)Send(message);
        }

        public Beetle.Express.Clients.SyncTcpClient Connection
        {
            get
            {
                return mConnection;
            }
        }

        public object Read()
        {
            return mConnection.ReceiveMessage();
        }

        public RESULT Read<RESULT>()
        {
            return (RESULT)Read();
        }

    }

}
