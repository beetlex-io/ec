using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
using ProtoBuf;
namespace DataAccess
{
    [MessageID(0x1)]
    [ProtoContract]
    public class CustomerSearch
    {

    }

    [MessageID(0x2)]
    [ProtoContract]
    public class EmployeeSearch
    {

    }

    [MessageID(0x3)]
    [ProtoContract]
    public class OrderSearch
    {
        [ProtoMember(1)]
        public string CustomerID { get; set; }
        [ProtoMember(2)]
        public int EmployeeID { get; set; }
    }

    [MessageID(0x4)]
    [ProtoContract]
    public class Customer
    {

        [ProtoMember(1)]
        public string CustomerID { get; set; }
        [ProtoMember(2)]
        public string CompanyName { get; set; }
        [ProtoMember(3)]
        public string ContactName { get; set; }
        public override string ToString()
        {
            return CompanyName + "(" + ContactName + ")";
        }
    }

    [MessageID(0x5)]
    [ProtoContract]
    public class Employee
    {
        [ProtoMember(1)]
        public int EmployeeID { get; set; }
        [ProtoMember(2)]
        public string LastName { get; set; }
        [ProtoMember(3)]
        public string FirstName { get; set; }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
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

    [MessageID(0x7)]
    [ProtoContract]
    public class OrderDetail
    {
        [ProtoMember(1)]
        public int OrderID { get; set; }
        [ProtoMember(2)]
        public int ProductID { get; set; }
        [ProtoMember(6)]
        public string ProductName { get; set; }
        [ProtoMember(3)]
        public decimal UnitPrice { get; set; }
        [ProtoMember(4)]
        public decimal Quantity { get; set; }
        [ProtoMember(5)]
        public decimal Discount { get; set; }
    }

    [MessageID(0x8)]
    [ProtoContract]
    public class GetDetail
    {
        [ProtoMember(1)]
        public int OrderID { get; set; }
    }
}
