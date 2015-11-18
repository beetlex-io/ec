using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
using ProtoBuf;
namespace HelloWord.Server
{
    [Controller]
    public class Program
    {
        static void Main(string[] args)
        {
            ECServer.Open();
            System.Threading.Thread.Sleep(-1);
        }

        public string HelloWord(ISession session,Hello e)
        {
            return string.Format("hello {0} [say time:{1}]", e.Name, DateTime.Now);
        }
    }

    [MessageID(0x1)]
    [ProtoContract]
    public class Hello
    {
        [ProtoMember(1)]
        public string Name { get; set; }
    }
}
