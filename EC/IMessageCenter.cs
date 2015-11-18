using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EC.Events;

namespace EC
{
    public interface IMessageCenter
    {
        void Init(IApplication application);

        byte[] GetMessageTypeData(Type type);

        Type GetMessageType(System.IO.Stream stream);

        void ProcessMessage(object message, ISession context);

        event EventHandler<EventMessageProcessArgs> MessageExecting;

        string Name { get; }

        IList<object> Controllers
        {
            get;
        }
    }
}
