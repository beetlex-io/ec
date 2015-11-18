using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Messages;
namespace EC.TestClient
{

    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Timer mTimer;

            try
            {
                DateTime dt;
                ProtoClient client = new ProtoClient("127.0.0.1");
                client.Receive = (o, e) =>
                {
                    Console.WriteLine("Receive From Server:{0}", e.Message);
                };
                User user = new User { EMail = "henryfan@msn.com", Name = "henry" };
                client.Send(user);
                IUserService us = client.CreateInstance<IUserService>();
                user = us.Register(user);
                Console.WriteLine(user.CreateTime);


                user = us.Register("henry", null);
                Console.WriteLine(user.CreateTime);

                user = us.Register("henry", "henryfan@msn.com", out dt);
                Console.WriteLine(dt);

                user = us.ReturnNull();
                Console.WriteLine(user == null);


                us.GetTime(out dt);

                Console.WriteLine(dt);
                //mTimer = new System.Threading.Timer(d =>
                //{
                //    DateTime s;
                //    us.GetTime(out s);
                //    Console.WriteLine(s);
                //}, null, 1000, 1000);

            }
            catch (Exception e_)
            {
                Console.WriteLine(e_);
            }
            Console.Read();


        }
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
