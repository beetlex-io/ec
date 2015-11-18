using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Remoting
{
    class MethodHandler
    {
        public object Obj { get; set; }

        public System.Reflection.MethodInfo Method { get; set; }



        public System.Reflection.ParameterInfo[] Parameters
        {
            get;
            set;
        }

        public object Execute(object[] parameters)
        {
            return Method.Invoke(Obj, parameters);
        }
    }
}
