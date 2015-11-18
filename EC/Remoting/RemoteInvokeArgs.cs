using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Remoting
{
    public class RemoteInvokeArgs
    {
        public RemoteInvokeArgs(RPC.MethodCall call)
        {
            CallID = call.ID;
            if (call.Parameters.Count > 0)
            {
                Parameters = new object[call.Parameters.Count];
            }
            else
            {
                Parameters = new object[0];
                mHasCompleted = true;
            }
            mCall = call;
            ParameterTypes = call.Parameters;
        }

        private int mParameterIndex = 0;

        private bool mHasCompleted = false;

        private RPC.MethodCall mCall;

        public long CallID { get; set; }

        public object[] Parameters { get; set; }

        public bool HasCompleted
        {
            get
            {
                return mHasCompleted;
            }
        }
        public bool AddParameter(object obj)
        {
            Parameters[mParameterIndex] = obj;
            mParameterIndex++;
            mHasCompleted = mParameterIndex == Parameters.Length;
            return mHasCompleted;
        }
        public IList<string> ParameterTypes
        {
            get;
            private set;
        }

        public string GetKey()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(mCall.Service).Append(".").Append(mCall.Method).Append("(");
            for (int i = 0; i < ParameterTypes.Count; i++)
            {
                if (i > 0)
                    sb.Append(",");
                sb.Append(ParameterTypes[i]);
            }
            sb.Append(")");
            return sb.ToString();
        }


    }
}
