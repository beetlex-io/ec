using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EC;
using ProtoBuf;

namespace Remoting.Service
{
    [MessageID(0x010)]
    [ProtoContract]
    public class User
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public string EMail { get; set; }
        [ProtoMember(3)]
        public DateTime CreateTime
        {
            get;
            set;
        }
    }
}
