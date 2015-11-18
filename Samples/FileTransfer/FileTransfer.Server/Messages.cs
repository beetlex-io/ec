using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
using ProtoBuf;
namespace FileTransfer
{
    [MessageID(0x1)]
    [ProtoContract]
    public class CD
    {
        [ProtoMember(1)]
        public string Name { get; set; }
    }

    [MessageID(0x2)]
    [ProtoContract]
    public class Resource
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public ResourceType Type { get; set; }
        [ProtoMember(3)]
        public string Size { get; set; }
    }

    public enum ResourceType
    {
        File = 0,
        Folder = 1
    }

    [MessageID(0x3)]
    [ProtoContract]
    public class Download
    {
        [ProtoMember(1)]
        public string File { get; set; }
    }

    [MessageID(0x6)]
    [ProtoContract]
    public class FileInfo
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public long Size { get; set; }
    }

    [MessageID(0x4)]
    [ProtoContract]
    public class FileBlock
    {
        [ProtoMember(1)]
        public byte[] Data { get; set; }
        [ProtoMember(2)]
        public bool Eof { get; set; }
    }

    [MessageID(0x5)]
    [ProtoContract]
    public class Error
    {
        [ProtoMember(1)]
        public string Message { get; set; }
    }
}
