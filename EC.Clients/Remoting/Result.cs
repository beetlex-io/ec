using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Remoting
{
    public class Result
    {
        private Dictionary<string, object> mParameters = new Dictionary<string, object>();

        public ResultStatus Status { get; set; }

        public string Error { get; set; }

        public object Data { get; set; }

        public Dictionary<string, object> Parameters
        {
            get
            {
                return mParameters;
            }
        }
        public object this[string name]
        {
            get
            {
                return Parameters[name];
            }
            set
            {
                Parameters[name] = value;
            }
        }
    }
}
