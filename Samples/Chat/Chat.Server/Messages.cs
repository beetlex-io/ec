using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EC;
using ProtoBuf;
namespace Chat
{
    [MessageID(0x0001)]
    [ProtoContract]
    public class Login
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public string From { get; set; }
    }
    [MessageID(0x0003)]
    [ProtoContract]
    public class Signout
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public string From { get; set; }
    }
    [MessageID(0x0002)]
    [ProtoContract]
    public class Say
    {
        [ProtoMember(1)]
        public string Content { get; set; }
        [ProtoMember(3)]
        public string From { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
    }
}
