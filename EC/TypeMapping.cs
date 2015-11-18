using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=true)]
    public class TypeMappingAttribute:Attribute
    {
        public TypeMappingAttribute(short id, Type type)
        {
            MessageID = id;
            Type = type;
        }
        public Type Type
        {
            get;
            set;
        }
        public short MessageID
        {
            get;
            set;
        }
    }
}
