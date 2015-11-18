using Peanut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
namespace DataAccess.Server
{
    [EC.Controller]
    public class Program
    {
        static void Main(string[] args)
        {
            DBContext.SetConnectionDriver<SqliteDriver>(DB.DB1);
            DBContext.SetConnectionString(DB.DB1, "Data Source=northwindEF.db;Pooling=true;FailIfMissing=false;");
            ECServer.Open();
            System.Threading.Thread.Sleep(-1);
        }

        public IList<Employee> OnEmployeeSearch(ISession session, EmployeeSearch e)
        {
            return new Expression().List<Models.Employees, Employee>();
        }

        public IList<Customer> OnCustomerSearch(ISession session, CustomerSearch e)
        {
            return new Expression().List<Models.Customers, Customer>();
        }

        public IList<Order> OnOrderSearch(ISession session, OrderSearch e)
        {
            Expression exp = new Expression();
            if (e.CustomerID != null)
                exp &= Models.Orders.customerID == e.CustomerID;
            if (e.EmployeeID > 0)
                exp &= Models.Orders.employeeID == e.EmployeeID;
            return exp.List<Models.Orders, Order>();
        }

        public IList<OrderDetail> GetOrderDetail(ISession session, GetDetail e)
        {
            Expression exp = Models.OrderDetails.orderID == e.OrderID;
            JoinTable jt = Models.OrderDetails.productID.InnerJoin(Models.Products.productID);
            jt.Select("OrderDetails.*", Models.Products.productName.Name);
            return exp.List<OrderDetail>(jt);
        }

    }
}
