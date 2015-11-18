using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beetle.Express;

namespace EC.Implement
{
    public class ProtobufPacket : PacketAnalyzer
    {


        public ProtobufPacket()
        {

        }



        public override object GetMessage(System.IO.Stream stream)
        {
            Type type = MessageCenter.GetMessageType(stream);
            if (stream.Position == stream.Length)
                return null;
            return ProtoBuf.Meta.RuntimeTypeModel.Default.Deserialize(stream, null, type);
        }

        public override Beetle.Express.IData GetMessageData(object message)
        {
            Beetle.Express.IData data = null;
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                stream.Write(new byte[4], 0, 4);
                byte[] typedata = MessageCenter.GetMessageTypeData(message.GetType());
                stream.Write(typedata, 0, typedata.Length);
              

                ProtoBuf.Meta.RuntimeTypeModel.Default.Serialize(stream, message);

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
                        ProtoBuf.Meta.RuntimeTypeModel.Default.Serialize(stream, message.Value);
                    buffer = stream.GetBuffer();
                    BitConverter.GetBytes((int)stream.Length - 4 - (int)index).CopyTo(buffer, index);
                    index = stream.Position;
                }

                data = new Data(stream.GetBuffer(), (int)stream.Length);
                data.Tag = messages;

            }
            return data;
        }
        public override object Clone()
        {
            return new ProtobufPacket { Application = Application, MessageCenter = MessageCenter };
        }


        public override string Name
        {
            get { return "Portobuf"; }
        }


    }
}
