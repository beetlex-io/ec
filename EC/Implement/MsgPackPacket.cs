using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beetle.Express;
using MsgPack.Serialization;

namespace EC.Implement
{
    public class MsgPackPacket : PacketAnalyzer
    {
        public override object GetMessage(System.IO.Stream stream)
        {
            Type type = MessageCenter.GetMessageType(stream);
            if (stream.Position == stream.Length)
                return null;
            var serializer = SerializationContext.Default.GetSerializer(type);
            return serializer.Unpack(stream);
        }

        public override Beetle.Express.IData GetMessageData(object message)
        {
            Beetle.Express.IData data = null;
            Type type = message.GetType();
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                stream.Write(new byte[4], 0, 4);
                byte[] typedata = MessageCenter.GetMessageTypeData(type);
                stream.Write(typedata, 0, typedata.Length);
                var serializer = SerializationContext.Default.GetSerializer(type);
                serializer.Pack(stream, message);

                data = new Data(stream.GetBuffer(), (int)stream.Length);
                data.Tag = message;
                BitConverter.GetBytes((int)stream.Length - 4).CopyTo(data.Array, 0);
            }
            return data;
        }
        public override IData GetMessageData(IList<Message> messages)
        {
            Beetle.Express.IData data = null;
            byte[] buffer;
            long index = 0;
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                foreach (Message message in messages)
                {

                    stream.Write(new byte[4], 0, 4);
                    byte[] typedata = MessageCenter.GetMessageTypeData(message.Type);
                    stream.Write(typedata, 0, typedata.Length);
                    if (message.Value != null)
                    {
                        var serializer = SerializationContext.Default.GetSerializer(message.Type);
                        serializer.Pack(stream, message.Value);
                    }
                    buffer = stream.GetBuffer();
                    BitConverter.GetBytes((int)stream.Length - 4 - (int)index).CopyTo(buffer, index);
                    index = stream.Position;
                }

                data = new Data(stream.GetBuffer(), (int)stream.Length);
                data.Tag = messages;

            }
            return data;
        }

        public override string Name
        {
            get { return "MsgPacket"; }
        }
        public override object Clone()
        {
            return new MsgPackPacket { Application = Application, MessageCenter = MessageCenter };
        }


    }
}
