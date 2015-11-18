using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC
{
    public interface IPacketAnalyzer:Beetle.Express.IPackage,ICloneable
    {
        IApplication Application { get; set; }

        IMessageCenter MessageCenter { get; set; }

        Beetle.Express.IData GetMessageData(IList<Message> messages);

        string Name { get; }
    }
}
