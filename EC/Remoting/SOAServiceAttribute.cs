using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Remoting
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SOAServiceAttribute:Attribute
    {

        public SOAServiceAttribute(params Type[] services)
        {
            Services = services;
        }

        public Type[] Services
        {
            get;
            private set;
        }
    }
}
