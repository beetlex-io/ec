using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace EC.Remoting.RPC
{
    [ProtoContract]
    public class MethodCall
    {
        public MethodCall()
        {
            Parameters = new List<string>();
            ID = System.Threading.Interlocked.Increment(ref mID);
            Headers = new List<Header>();
        }

          [ProtoMember(100)]
        public List<Header> Headers { get; set; }

        private static long mID = 1;

        [ProtoMember(99)]
        public long ID { get; set; }

        [ProtoMember(1)]
        public string Service { get; set; }
        [ProtoMember(2)]
        public string Method { get; set; }
        [ProtoMember(3)]
        public IList<string> Parameters
        {
            get;
            set;
        }
    }
}
