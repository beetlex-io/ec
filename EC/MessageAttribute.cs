﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageIDAttribute:Attribute
    {
        public MessageIDAttribute(short msgid)
        {
            ID = msgid;
        }
        public short ID
        {
            get;
            set;
        }
    }
}
