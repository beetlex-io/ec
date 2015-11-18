using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beetle.Express;
namespace EC
{
    class NetHandler : Beetle.Express.IServerHandler
    {
        private Implement.Application mApplication;

        public IApplication Application
        {
            get
            {
                return mApplication;

            }
            set
            {
                mApplication = (Implement.Application)value;
            }
        }

        private ISession GetSession(IChannel channel)
        {
            ISession result = (ISession)channel["_session"];
            if (result == null)
            {
                result = new Implement.Session { Application = Application, Channel = channel };
                channel["_session"] = result;
            }
            return result;
        }

        public void Connect(Beetle.Express.IServer server, Beetle.Express.ChannelConnectEventArgs e)
        {

            try
            {
                mApplication.OnConnected(new Events.EventSessionConnectArgs { Application = Application, ChannelConnectArgs = e });
            }
            catch (Exception e_)
            {
                "{0} process connect event error".Log4Error(e_, e.Channel.EndPoint);
            }
            if (!e.Cancel)
            {
                e.Channel.Package = (IPackage)Application.PacketAnalyzer.Clone();
                e.Channel.Package.Receive = OnReceiveMessage;
                e.Channel.Package.Channel = e.Channel;
                "{0} connected!".Log4Info(e.Channel.EndPoint);
            }


        }

        private void OnReceiveMessage(object sender, PackageReceiveArgs e)
        {
            Application.MessageCenter.ProcessMessage(e.Message, GetSession(e.Channel));
        }

        public void Disposed(Beetle.Express.IServer server, Beetle.Express.ChannelEventArgs e)
        {

            try
            {
                mApplication.OnDisconnected(new Events.EventSessionArgs { Application = Application, Session = GetSession(e.Channel) });
            }
            catch (Exception e_)
            {
                "{0}  process  disconnected event error".Log4Error(e_, e.Channel.EndPoint);
            }

            "{0} disconnected!".Log4Info(e.Channel.EndPoint);
            if (e.Channel.Package != null)
            {
                ((IDisposable)e.Channel.Package).Dispose();

            }
            GetSession(e.Channel).Dispose();
        }

        public void Error(Beetle.Express.IServer server, Beetle.Express.ErrorEventArgs e)
        {
            if (e.Channel != null)
            {
                "{0} channel error".Log4Error(e.Error, e.Channel.EndPoint);
            }
            else
            {
                "ec application error ".Log4Error(e.Error);
            }
            mApplication.OnError(new Events.EventApplicationErrorArgs { Application=mApplication,Info=e });

        }

        public void Opened(Beetle.Express.IServer server)
        {

        }

        public void Receive(Beetle.Express.IServer server, Beetle.Express.ChannelReceiveEventArgs e)
        {
            if(!e.Channel.IsDisposed)
                e.Channel.Package.Import(e.Data.Array, e.Data.Offset, e.Data.Count);
        }

        public void SendCompleted(Beetle.Express.IServer server, Beetle.Express.ChannelSendEventArgs e)
        {



            try
            {
                mApplication.OnSendCompleted(new Events.EventDataSendCompletedArgs { Application = Application, Info = e, Session = GetSession(e.Channel) });

            }
            catch (Exception e_)
            {
                "process DataSendCompleted event error!".Log4Error(e_);
            }




        }
    }
}
