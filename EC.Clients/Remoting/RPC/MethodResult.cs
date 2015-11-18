using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace EC.Remoting.RPC
{
    [ProtoContract]
    public class MethodResult
    {
        [ProtoMember(100)]
        public List<Header> Headers { get; set; }
        [ProtoMember(99)]
        public long ID { get; set; }
        [ProtoMember(1)]
        public ResultStatus Status { get; set; }
        [ProtoMember(2)]
        public string Error { get; set; }
        [ProtoMember(3)]
        public bool IsVoid { get; set; }
        [ProtoMember(4)]
        public string[] Parameters { get; set; }
    }
}
