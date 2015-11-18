using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beetle.Express;
using EC.Events;
namespace EC
{
    public interface IApplication:IDisposable
    {
        string Host { get; set; }

        int Port { get; set; }

        string Http { get; set; }


        object this[string key]
        {
            get;
            set;
        }

        int PacketMaxsize { get; set; }


        IServer Server
        {
            get;
        }

        IPacketAnalyzer PacketAnalyzer { get; set; }

        IMessageCenter MessageCenter { get; set; }

        void Open();

        IList<IAppModel> Models
        {
            get;
        }

        IList<FilterAttribute> Filters
        {
            get;
        }

        IDictionary<string, object> Status
        {
            get;
        }



        event EventHandler<EventApplicationArgs> LoadCompleted;

        event EventHandler<EventDataSendCompletedArgs> SendCompleted;

        event EventHandler<EventSessionConnectArgs> Connected;

        event EventHandler<EventSessionArgs> Disconnected;

        event EventHandler<EventMethodProcessArgs> MethodProcess;

        event EventHandler<EventApplicationErrorArgs> Error;
    }
}
