using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beetle.Express;

namespace EC
{
    public abstract class Packet : Beetle.Express.IPackage
    {
        private static Implement.TypeMapper mTypeMapper = null;

        internal static Implement.TypeMapper TypeMapper
        {
            get
            {
                if (mTypeMapper == null)
                    mTypeMapper = Utils.GetMessageMapping();
                return mTypeMapper;
            }
        }

        public static void Register(short msgid, Type type)
        {
            TypeMapper.Register(msgid, type);
        }

        public Packet()
        {

        }

        private bool mLoading = false;

        private CheckSize mCheckSize = null;

        private System.IO.MemoryStream mStream = null;

        public void Import(byte[] data, int start, int count)
        {
            try
            {
                if (mCheckSize == null)
                {
                    mCheckSize = new CheckSize();

                }
                while (count > 0)
                {
                    if (!mLoading)
                    {
                        mCheckSize.Reset();
                        mStream = new System.IO.MemoryStream();
                        mLoading = true;
                    }
                    if (mCheckSize.Length == -1)
                    {
                        while (count > 0 && mCheckSize.Length == -1)
                        {
                            mCheckSize.Import(data[start]);
                            start++;
                            count--;
                        }
                    }
                    else
                    {

                        if (OnImport(data, ref start, ref count))
                        {
                            mLoading = false;
                            if (this.Receive != null)
                            {
                                mStream.Position = 0;
                                PackageReceiveArgs e = new PackageReceiveArgs();
                                e.Channel = this.Channel;
                                e.Message = GetMessage(mStream);
                                if (Receive != null)
                                    Receive(this, e);
                            }
                        }
                    }
                }
            }
            catch (Exception e_)
            {
                throw e_;
            }

        }

        private bool OnImport(byte[] data, ref int start, ref int count)
        {
            if (count >= mCheckSize.Length)
            {
                mStream.Write(data, start, mCheckSize.Length);
                start += mCheckSize.Length;
                count -= mCheckSize.Length;
                return true;
            }
            else
            {
                mStream.Write(data, start, count);
                start += count;
                mCheckSize.Length -= count;
                count = 0;
                return false;
            }

        }

        class CheckSize
        {
            public int Length = -1;

            private int mIndex;

            public byte[] LengthData = new byte[4];

            public void Import(byte value)
            {
                LengthData[mIndex] = value;
                if (mIndex == 3)
                {
                    Length = BitConverter.ToInt32(LengthData, 0);

                }
                else
                {
                    mIndex++;
                }
            }

            public void Reset()
            {
                Length = -1;
                mIndex = 0;
            }
        }

        public abstract object GetMessage(System.IO.Stream stream);


        public abstract Beetle.Express.IData GetMessageData(object message);

        public abstract Beetle.Express.IData GetMessageData(IList<Message> message);

        public void Reset()
        {
            if (mCheckSize != null)
                mCheckSize.Reset();
            mLoading = false;
        }


        public Beetle.Express.IChannel Channel
        {
            get;
            set;
        }

        public Beetle.Express.EventPackageReceive Receive
        {
            get;
            set;
        }


        public virtual void Recover(IData data)
        {

        }


    }
}
