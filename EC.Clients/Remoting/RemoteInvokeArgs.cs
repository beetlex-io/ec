using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Remoting
{
    public class RemoteInvokeArgs
    {
        public RemoteInvokeArgs()
        {
            Parameters = new object[0];
            ParameterTypes = new List<string>();
        }

        public string Interface { get; set; }

        public string Method { get; set; }

        public object[] Parameters { get; set; }

        public System.Reflection.ParameterInfo[] ParameterInfos
        {
            get;
            set;
        }

        public IList<string> ParameterTypes
        {
            get;
            private set;
        }

        public ICommunicationObject CommunicationObject
        {
            get;
            set;
        }
       


        public string GetKey()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Interface).Append(".").Append(Method).Append("(");
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
