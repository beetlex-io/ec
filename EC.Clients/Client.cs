using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beetle.Express;
using EC.Remoting;

namespace EC.Clients
{

    public interface IClient
    {
        bool Send(object message);

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

        void Push(MethodReturnArgs args);



    }

    public class Client<T> : IClient where T : Beetle.Express.IPackage, new()
    {
        public Client(string host, int port = 10034)
        {
            mConnection = new Beetle.Express.Clients.TcpClient(host, port, new T());
            mConnection.Package.Receive = OnReceive;
            mPool.Push(new MethodReturnArgs());
            mPool.Push(new MethodReturnArgs());
            mPool.Push(new MethodReturnArgs());
            mPool.Push(new MethodReturnArgs());
            mPool.Push(new MethodReturnArgs());
        }

        private Beetle.Express.Clients.TcpClient mConnection;

        public bool Send(object message)
        {
            return mConnection.SendMessage(message);
        }

        private MethodReturnArgs mMethodReturnArgs = null;

        private Dictionary<long, MethodReturnArgs> mRemotingMethods = new Dictionary<long, MethodReturnArgs>(64);

        private void OnReceive(object sender, PackageReceiveArgs e)
        {
            lock (this)
            {
                if (e.Message is Remoting.RPC.MethodResult)
                {
                    Remoting.RPC.MethodResult result = (Remoting.RPC.MethodResult)e.Message;
                    if (mRemotingMethods.TryGetValue(result.ID, out mMethodReturnArgs))
                    {
                        mMethodReturnArgs.Import(result);
                    }
                }
                else
                {
                    if (mMethodReturnArgs == null)
                    {
                        if (Receive != null)
                            Receive(sender, e);
                    }
                    else
                    {
                        if (mMethodReturnArgs.Status == InvokeStatus.Return)
                        {
                            mMethodReturnArgs.SetReturn(e.Message);
                        }
                        else if (mMethodReturnArgs.Status == InvokeStatus.Parameter)
                        {
                            mMethodReturnArgs.AddParameter(e.Message);
                        }
                    }
                }
                if (mMethodReturnArgs != null && mMethodReturnArgs.Status == InvokeStatus.Completed)
                {
                    mMethodReturnArgs.Completed();
                    mMethodReturnArgs = null;
                }
            }

        }

        private Stack<MethodReturnArgs> mPool = new Stack<MethodReturnArgs>();

        public Beetle.Express.EventPackageReceive Receive
        {
            get;
            set;
        }

        public SERVICE CreateInstance<SERVICE>()
        {
            SERVICE service = ProxyFactory.CursorFactory.CreateInstance<SERVICE>();
            ((ICommunicationObject)service).Client = this;
            return service;
        }

        public Beetle.Express.Clients.TcpClient Connection
        {
            get
            {
                return mConnection;
            }
        }


        MethodReturnArgs IClient.Pop()
        {
            MethodReturnArgs result;
            lock (mPool)
            {
                if (mPool.Count > 0)
                {
                    result = mPool.Pop();
                    result.Reset();
                }
                result = new MethodReturnArgs();
                return result;
            }
        }

        void IClient.Push(MethodReturnArgs args)
        {
            lock (mPool)
            {
                mPool.Push(args);
            }
        }
        void IClient.RegisterRemote(long id, MethodReturnArgs e)
        {
            lock (mRemotingMethods)
            {
                mRemotingMethods[id] = e;
            }
        }

        void IClient.UnRegisterRemote(long id)
        {
            lock (mRemotingMethods)
            {
                mRemotingMethods.Remove(id);
            }
        }
    }
}
