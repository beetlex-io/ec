using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beetle.Express;

namespace EC.Events
{
    public class EventApplicationArgs : EventArgs
    {
        public IApplication Application
        {
            get;
            internal set;
        }
    }

    
    public class EventApplicationErrorArgs : EventApplicationArgs
    {
        public ErrorEventArgs Info
        {
            get;
            internal set;
        }
    }
    public class EventSessionArgs : EventApplicationArgs
    {
        public ISession Session
        {
            get;
            internal set;
        }
    }
    public class EventSessionConnectArgs : EventApplicationArgs
    {
        public ChannelConnectEventArgs ChannelConnectArgs
        {

            get;
            internal set;
        }
    }

    public class EventMessageProcessArgs:EventApplicationArgs
    {
        public ISession Session
        {
            get;
            internal set;
        }
        public bool Cancel { get; set; }
        public Object Message
        {
            get;
            set;
        }
    }

    public class EventMethodProcessArgs : EventApplicationArgs
    {
        public IMethodContext Method
        {
            get;
            internal set;
        }
       
        public ISession Session
        {
            get;
            internal set;
        }
    }


    public class EventCommandArgs : EventApplicationArgs
    {
        public string Value
        {
            get;
            internal set;
        }
        public string Result
        {
            get;
            set;
        }
    }

    public class EventDataSendCompletedArgs : EventApplicationArgs
    {
        public ISession Session
        {
            get;
            internal set;
        }
        public ChannelSendEventArgs Info
        {
            get;
            internal set;
        }
    }
}
