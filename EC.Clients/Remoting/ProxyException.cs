using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Remoting
{
    public class ProxyException:Exception
    {
        public ProxyException()
        {
        }
        public ProxyException(string error) : base(error) { }
        public ProxyException(string error,Exception interError) : base(error,interError) { }
    }
}
