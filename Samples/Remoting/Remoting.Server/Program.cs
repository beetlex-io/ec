using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EC;
using EC.Remoting;
using Remoting.Service;

namespace Remoting.Server
{
    [SOAService(typeof(Service.IUserService))]
    class Program : IUserService
    {
        static void Main(string[] args)
        {

            System.Threading.ThreadPool.SetMaxThreads(60, 60);
            System.Threading.ThreadPool.SetMinThreads(40, 40);
            ECServer.Open();
            System.Threading.Thread.Sleep(-1);
        }

        public Service.User Register(string name, string email)
        {
            User user = new User();
            user.EMail = email;
            user.Name = name;
            user.CreateTime = DateTime.Now;
            return user;
        }
    }

}
