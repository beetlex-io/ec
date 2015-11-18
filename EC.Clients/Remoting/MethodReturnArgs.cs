using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Remoting
{
    public class MethodReturnArgs
    {
        public MethodReturnArgs()
        {
            Parameters = new List<object>(4);
            ParameterNames = new List<string>();
        }

        public int ID { get; set; }

        private System.Threading.Semaphore mWait = new System.Threading.Semaphore(0, 3);

        public void Import(RPC.MethodResult result)
        {
            mMethodResult = result;
            if (MethodResult.Status == ResultStatus.Error)
            {
                Status = InvokeStatus.Completed;
            }
            else
            {
                Status = InvokeStatus.Return;
                if (result.Parameters != null)
                    foreach (string p in result.Parameters)
                    {
                        if (!string.IsNullOrEmpty(p))
                            ParameterNames.Add(p);
                    }

                if (result.IsVoid && ParameterNames.Count == 0)
                    Status = InvokeStatus.Completed;
                else if (result.IsVoid && ParameterNames.Count > 0)
                    Status = InvokeStatus.Parameter;
                else
                    Status = InvokeStatus.Return;
            }


        }

        private RPC.MethodResult mMethodResult;


        public RPC.MethodResult MethodResult
        {
            get
            {
                return mMethodResult;
            }
        }

        public object Result
        {
            get;
            set;
        }

        public IList<object> Parameters { get; private set; }

        public IList<string> ParameterNames { get; private set; }

        public InvokeStatus Status
        {
            get;
            set;
        }

        public bool Wait()
        {
            return mWait.WaitOne(30000);

        }

        public void Reset()
        {

            ParameterNames.Clear();
            Parameters.Clear();
            Status = InvokeStatus.Nono;
        }

        public void Completed()
        {
            mWait.Release();
        }

        public void SetReturn(object obj)
        {
            Result = obj;


            if (ParameterNames.Count > 0)
                Status = InvokeStatus.Parameter;
            else
                Status = InvokeStatus.Completed;

        }
        public void AddParameter(object obj)
        {
            Parameters.Add(obj);
            if (ParameterNames.Count == Parameters.Count)
                Status = InvokeStatus.Completed;

        }
    }
    public enum InvokeStatus
    {
        Nono,
        Receiving,
        Return,
        Parameter,
        Completed
    }
}
