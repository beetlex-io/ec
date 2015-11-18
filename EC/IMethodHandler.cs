using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC
{
    public interface IMethodHandler
    {
        object Execute(IMethodContext context, object[] parameters);

        FilterAttribute[] Filters
        {
            get;
        }

        bool UseThreadPool
        {
            get;
        }

        object Controller
        {
            get;
        }
        System.Reflection.ParameterInfo[] Parameters
        {
            get;
            set;
        }
        System.Reflection.MethodInfo Info
        {
            get;
        }
    }

}
