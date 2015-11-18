using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beetle.Express;
using EC.Events;

namespace EC.Implement
{
    class Application : IApplication
    {

        public Application()
        {
            initDefault();
        }

        public Application(string section)
        {
            ApplicatonSection AS = (ApplicatonSection)System.Configuration.ConfigurationManager.GetSection(section);
            if (AS != null)
            {
                initSection(AS);
            }
            else
            {
                initDefault();
            }
        }

        private bool mSendUseQueue = true;

        private bool mReceiveUseQueue = true;

        private bool mSyncSend = false;

        private int mReceiveThreads = 1;

        private int mSendThreads = 1;

        private void initDefault()
        {
            PacketMaxsize = 1024 * 1024 * 50;
            Port = 10034;
            Http = "http://localhost:10035/";
            PacketAnalyzer = new Implement.ProtobufPacket();
            MessageCenter = new Remoting.MessageCenter();
        }

        private void initSection(ApplicatonSection section)
        {
            PacketMaxsize = section.PacketMaxsize;
            Host = section.Host;
            Port = section.Port;
            Http = section.Http;
            mSendThreads = section.SendThreads;
            mReceiveThreads = section.ReceiveThreads;
            mSyncSend = section.SyncSend;
            mSendUseQueue = section.SendQueue;
            mReceiveUseQueue = section.ReceiveQueue;
            LoadPacketAnalyzer(section.PacketAnalyzer);
            LoadMessageCenter(section.MessageCenter);

        }

        private void LoadPacketAnalyzer(string name)
        {
            Type type = null;
            if (!string.IsNullOrEmpty(name))
            {
                type = Type.GetType(name);
                if (type != null)
                {
                    if (type.GetInterface("EC.IPacketAnalyzer") == null)
                    {
                        "{0} type not is packet analyzer".Log4Error(name);
                        type = null;
                    }
                }
                else
                {
                    "{0} packet analyzer notfound".Log4Error(name);
                }
            }
            if (type == null)
            {
                PacketAnalyzer = new Implement.ProtobufPacket();
            }
            else
            {
                PacketAnalyzer = (IPacketAnalyzer)Activator.CreateInstance(type);
            }
        }

        private void LoadMessageCenter(string name)
        {
            Type type = null;
            if (!string.IsNullOrEmpty(name))
            {
                type = Type.GetType(name);
                if (type != null)
                {
                    if (type.GetInterface("EC.IMessageCenter") == null)
                    {
                        "{0} type not is message center".Log4Error(name);
                        type = null;
                    }
                }
                else
                {
                    "{0} type  message center notfound".Log4Error(name);
                }
            }
            if (type == null)
            {
                MessageCenter = new Remoting.MessageCenter();
            }
            else
            {
                MessageCenter = (IMessageCenter)Activator.CreateInstance(type);
            }
        }

        private Dictionary<string, object> mProperties = new Dictionary<string, object>();

        private Dictionary<string, object> mStatus = new Dictionary<string, object>();

        private List<FilterAttribute> mFilters = new List<FilterAttribute>();

        private List<IAppModel> mModels = new List<IAppModel>();

        private IServer mServer;

        public string Host
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }

        public string Http
        {
            get;
            set;
        }

        public object this[string key]
        {
            get
            {
                object result = null;
                mProperties.TryGetValue(key, out result);
                return result;
            }
            set
            {
                mProperties[key] = value;
            }

        }

        public int PacketMaxsize
        {
            get;
            set;
        }

        public Beetle.Express.IServer Server
        {
            get { return mServer; }
        }

        public IPacketAnalyzer PacketAnalyzer
        {
            get;
            set;
        }

        public IMessageCenter MessageCenter
        {
            get;
            set;
        }

        public void Open()
        {
            LoadAppModule();
            ModelInit();
            MessageCenterInit();

            try
            {
                PacketAnalyzer.Application = this;
                PacketAnalyzer.MessageCenter = MessageCenter;
                mServer = Beetle.Express.ServerFactory.CreateTCP();
                mServer.Host = Host;
                mServer.Port = Port;
                NetHandler handler = new NetHandler();
                handler.Application = this;
                mServer.Handler = handler;
                mServer.Open(mReceiveUseQueue, mSendUseQueue, mSyncSend, mReceiveThreads, mSendThreads, "EC");
                "ec application started:[{2}@{3}] [message center:{0}] [packet analyzer:{1}]".Log4Info(MessageCenter.Name, PacketAnalyzer.Name, Host, Port);
                if (LoadCompleted != null)
                {
                    OnLoadCompleted(new EventApplicationArgs { Application = this });
                }
            }
            catch (Exception e_)
            {
                "ec application start error".Log4Error(e_);
            }

        }

        private void ModelInit()
        {
            foreach (IAppModel model in mModels)
            {
                try
                {
                    model.Init(this);
                    "load {0} app model success".Log4Info(model.Name);
                }
                catch (Exception e_)
                {
                    "load {0} app model error ".Log4Error(e_, model.Name);
                }
            }
        }

        private void MessageCenterInit()
        {
            try
            {
                MessageCenter.Init(this);
                "{0} message center init success ".Log4Info(MessageCenter.Name);
            }
            catch (Exception e_)
            {
                "{0} message center init error ".Log4Info(e_, MessageCenter.Name);
            }
        }

        private void LoadAppModule()
        {
            "app model loading".Log4Info();
            Utils.LoadAssembly(a =>
            {
                foreach (Type type in a.GetTypes())
                {
                    if (!type.IsAbstract && type.IsClass && type.GetInterface("EC.IAppModel") != null)
                    {
                        Models.Add((IAppModel)Activator.CreateInstance(type));
                    }
                }
            });
        }

        public IList<IAppModel> Models
        {
            get { return mModels; }
        }

        public void Dispose()
        {
            if (mServer != null)
            {
                mServer.Dispose();
                mServer = null;
            }
        }


        public IList<FilterAttribute> Filters
        {
            get { return mFilters; }
        }

        public IDictionary<string, object> Status
        {
            get
            {
                return Status;
            }
        }

        internal void OnLoadCompleted(EventApplicationArgs e)
        {
            try
            {
                if (LoadCompleted != null)
                    LoadCompleted(this, e);
            }
            catch (Exception err)
            {
            }
        }

        internal void OnSendCompleted(EventDataSendCompletedArgs e)
        {
            if (SendCompleted != null)
            {
                SendCompleted(this, e);
            }
        }



        public event EventHandler<EventDataSendCompletedArgs> SendCompleted;

        internal void OnConnected(EventSessionConnectArgs e)
        {
            try
            {
                if (Connected != null)
                    Connected(this, e);
            }
            catch (Exception err)
            {
            }
        }

        public event EventHandler<EventSessionConnectArgs> Connected;

        internal void OnDisconnected(EventSessionArgs e)
        {
            try
            {
                if (Disconnected != null)
                    Disconnected(this, e);
            }

            catch (Exception err)
            {
            }
        }

        public event EventHandler<EventSessionArgs> Disconnected;


        internal void OnMethodProcess(EventMethodProcessArgs e)
        {
            try
            {
                if (MethodProcess != null)
                    MethodProcess(this, e);
            }
            catch (Exception err)
            {
            }
        }

        public event EventHandler<EventMethodProcessArgs> MethodProcess;

        internal void OnError(EventApplicationErrorArgs e)
        {
            try
            {
                if (Error != null)
                    Error(this, e);
            }
            catch (Exception err)
            {
            }
        }

        public event EventHandler<EventApplicationErrorArgs> Error;


        public event EventHandler<EventApplicationArgs> LoadCompleted;
    }
}
