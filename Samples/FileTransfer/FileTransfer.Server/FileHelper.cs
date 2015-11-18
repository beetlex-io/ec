using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransfer
{
    public class FileHelper:IDisposable
    {
        private System.IO.Stream mStream;

        public FileHelper(string filename, bool readOnly = true)
        {
            if (readOnly)
            {
                mStream = System.IO.File.OpenRead(filename);
            }
            else
            {
                mStream = System.IO.File.Open(filename, System.IO.FileMode.Create);
            }
        }

        private int mBlockSize = 1024 * 8;

        public void Write(byte[] data, int offse, int count)
        {
            mStream.Write(data, offse, count);
            mStream.Flush();
        }

        public byte[] Read()
        {
            long scount = mStream.Length - mStream.Position;
            byte[] data;
            if (scount > mBlockSize)
            {
                data = new byte[mBlockSize];
            }
            else
            {
                data = new byte[(int)scount];
            }
            mStream.Read(data, 0, data.Length);
            return data;
        }

        public bool Eof
        {
            get
            {
                return mStream.Position == mStream.Length;
            }
        }

        public void Dispose()
        {
            if (mStream != null)
            {
                mStream.Flush();
                mStream.Close();
                mStream.Dispose();
            }
        }
    }
}
