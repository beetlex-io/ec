using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EC;
using ProtoBuf;

namespace Messages
{
    [MessageID(0x010)]
    [ProtoContract]
    public class User
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public string EMail { get; set; }
        [ProtoMember(3)]
        public DateTime CreateTime
        {
            get;
            set;
        }
    }


    [MessageID(0x020)]
    [ProtoContract]
    public class Query
    {
        [ProtoMember(1)]
        public string Name { get; set; }
    }
    [MessageID(0x6)]
    [ProtoContract]
    public class Order
    {
        [ProtoMember(1)]
        public int OrderID { get; set; }
        [ProtoMember(2)]
        public DateTime OrderDate { get; set; }
        [ProtoMember(3)]
        public DateTime RequiredDate { get; set; }
        [ProtoMember(4)]
        public DateTime ShippedDate { get; set; }
        [ProtoMember(5)]
        public decimal Freight { get; set; }
        [ProtoMember(6)]
        public string ShipName { get; set; }
        [ProtoMember(7)]
        public string ShipAddress { get; set; }
        [ProtoMember(8)]
        public string ShipCity { get; set; }
        [ProtoMember(9)]
        public string ShipRegion { get; set; }
        [ProtoMember(10)]
        public string ShipPostalCode { get; set; }
        [ProtoMember(11)]
        public string ShipCountry { get; set; }
    }

  
}
