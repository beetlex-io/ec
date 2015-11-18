using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC
{
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method,AllowMultiple=true)]
    public class FilterAttribute:Attribute
    {
        public virtual void Execute(IMethodContext context)
        {
            context.Execute();
        }
    }
}
