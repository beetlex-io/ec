using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C = System.Console;
using ProtoBuf;
using Messages;
using System.Threading;
using EC.Remoting;
namespace EC.Console
{
    [SOAService(typeof(IUserService),typeof(IOrderService))]
    class Program : IUserService,IOrderService
    {
        static void Main(string[] args)
        {         
            ECServer.Open();
            Thread.Sleep(-1);
        }
        public User Register(User user)
        {
            user.CreateTime = DateTime.Now;
            return user;
        }
        public void GetTime(out DateTime dt)
        {
            dt = DateTime.Now;
        }
        public User Register(string name, string email)
        {
            User user = new User() { Name = name, EMail = email, CreateTime = DateTime.Now };
            return user;
        }
        public User Register(string name, string email, out DateTime createTime)
        {
            createTime = DateTime.Now;
            User user = new User() { Name = name, EMail = email };
            return user;
        }


        public User ReturnNull()
        {
            return null;
        }

        public Messages.Order Get(int id)
        {
            Messages.Order order = new Messages.Order();
            order.OrderID = id;
            order.Freight = 3.4M;
            order.OrderDate = DateTime.Now;
            order.OrderID = 1234;
            order.RequiredDate = DateTime.Now;
            order.ShipAddress = "gz tian he long dong";
            order.ShipCity = "gz";
            order.ShipCountry = "cn";
            order.ShipName = "sf";
            order.ShippedDate = DateTime.Now.AddDays(10);
            order.ShipPostalCode = "510520";
            order.ShipRegion = "gd";
            return order;
        }

        public List<Messages.Order> List(int pages, int size)
        {
            List<Messages.Order> orders = new List<Messages.Order>();
            for (int i = 0; i < 10; i++)
            {
                Messages.Order order = new Messages.Order();
                order.Freight = 3.4M;
                order.OrderDate = DateTime.Now;
                order.OrderID = 1234;
                order.RequiredDate = DateTime.Now;
                order.ShipAddress = "gz tian he long dong";
                order.ShipCity = "gz";
                order.ShipCountry = "cn";
                order.ShipName = "sf";
                order.ShippedDate = DateTime.Now.AddDays(10);
                order.ShipPostalCode = "510520";
                order.ShipRegion = "gd";
                orders.Add(order);
            }
            return orders;
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

    public class LoginFilter : FilterAttribute
    {
        public override void Execute(IMethodContext context)
        {
            "login filter ->{0} execting".Log4Debug(context.Handler);
            base.Execute(context);
            "login filter ->{0} exected".Log4Debug(context.Handler);
        }
    }
    public class FilterModel : IAppModel
    {

        public string Name
        {
            get { return "Filter"; }
        }

        private System.Threading.Timer mTimer;

        public void Init(IApplication application)
        {
            //application.Filters.Add(new LoginFilter());
            application.Disconnected += (o, e) =>
            {
                "{0} disposed applicaion event".Log4Info(e.Session.Channel.EndPoint);

            };
            application.Connected += (o, e) =>
            {

                "{0} connect applicaion event".Log4Info(e.ChannelConnectArgs.Channel.EndPoint);

            };
            /*  application.SendCompleted += (o, e) =>
              {
                 "{0} send completed applicaion event".Log4Info(e.Session.Channel.EndPoint);
              };*/
            /* application.MethodProcess += (o, e) =>
             {
                 //application
                 e.Application["Path"] = @"c:\";
                 //sexxion
                 e.Session["folder"] = "aaa";
             };*/
            application.Error += (o, e) =>
            {
                "{0} channel error {1}".Log4Error(e.Info.Channel.EndPoint, e.Info.Error.Message);
            };
            mTimer = new System.Threading.Timer(o =>
            {
                application.Server.Send(new User { Name = Guid.NewGuid().ToString("N"),CreateTime = DateTime.Now }, application.Server.GetOnlines());
            }, null, 1000, 1000);

        }



        public string Command(string cmd)
        {
            throw new NotImplementedException();
        }
    }

    public class AdminFilter : FilterAttribute
    {
        public override void Execute(IMethodContext context)
        {
            "admin filter ->{0}".Log4Debug(context.Handler);
            base.Execute(context);
        }
    }
    [Controller]
    public class Controller
    {
        [SkipFilter(typeof(LoginFilter))]
        [ThreadPool]
        public User Regisetr(ISession session, User user)
        {
            user.CreateTime = DateTime.Now;
            "Register invoke[Name:{0} Email:{1}]".Log4Debug(user.Name, user.EMail);

            return user;
        }

        [AdminFilter]
        public IList<User> Search(ISession session, Query query)
        {
            "Search invoke".Log4Debug();
            List<User> users = new List<User>();
            users.Add(new User());
            users.Add(new User());
            return users;
        }
    }
}
