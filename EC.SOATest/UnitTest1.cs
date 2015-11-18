using System;
using System.Collections.Generic;
using Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EC.SOATest
{
    [TestClass]
    public class UnitTest1
    {
        private static ProtoClient client = new ProtoClient("127.0.0.1");
        [TestMethod]
        public void Register()
        {
            IUserService service = client.CreateInstance<IUserService>();
            User user = new User { EMail = "henryfan@msn.com", Name = "henry" };
            User result = service.Register(user);
            Assert.AreEqual(user.Name, result.Name);
            Assert.AreNotEqual(user.CreateTime, result.CreateTime);

        }
        [TestMethod]
        public void Register1()
        {
            IUserService service = client.CreateInstance<IUserService>();
            User result = service.Register("henry", "henryafn@msn.com");
            Assert.AreEqual("henry", result.Name);
        }

        [TestMethod]
        public void Register2()
        {
            IUserService service = client.CreateInstance<IUserService>();
            User result = service.Register(null, "henryafn@msn.com");
            Assert.IsNull(result.Name);
        }
        [TestMethod]
        public void Register3()
        {
            IUserService service = client.CreateInstance<IUserService>();
            User result = service.Register(null, null);
            Assert.IsNull(result.Name);
            Assert.IsNull(result.EMail);
        }
        [TestMethod]
        public void GetDT()
        {
            DateTime dt = DateTime.Now;
            IUserService service = client.CreateInstance<IUserService>();
            DateTime now;
            service.GetTime(out now);
            Assert.AreNotEqual(now, DateTime.MinValue);
            Assert.AreNotEqual(dt, now);

        }
        [TestMethod]
        public void ReturnNull()
        {
            IUserService service = client.CreateInstance<IUserService>();
            User result = service.ReturnNull();
            Assert.IsNull(result);
        }
        [TestMethod]
        public void GetOrder()
        {
            IOrderService orderservice = client.CreateInstance<IOrderService>();
            Order order = orderservice.Get(1234);
            Assert.AreEqual(order.OrderID, 1234);
        }
        [TestMethod]
        public void ListOrders()
        {
            IOrderService orderservice = client.CreateInstance<IOrderService>();
            IList<Order> orders = orderservice.List(1, 10);
            Assert.AreEqual(orders.Count, 10);
        }

    }
    public interface IOrderService
    {
        Order Get(int id);
        List<Order> List(int pages, int size);
    }
    public interface IUserService
    {
        User Register(User user);

        User Register(string name, string email);

        User Register(string name, string email, out DateTime createTime);

        User ReturnNull();

        void GetTime(out DateTime dt);
    }
}
