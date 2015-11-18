using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat.Server
{
    [EC.Controller]
    public class Program
    {
        static void Main(string[] args)
        {
            EC.ECServer.Open();
            System.Threading.Thread.Sleep(-1);
        }
        public void OnLogin(EC.ISession session, Chat.Login e)
        {
            session.Channel.Name = e.Name;
            e.From = session.Channel.EndPoint.ToString();
            foreach (Beetle.Express.IChannel other in session.Application.Server.GetOnlines())
            {
                if (other != session.Channel)
                    session.Application.Server.Send(e, other);
            }
        }
        public void OnSay(EC.ISession session, Chat.Say e)
        {
            e.Name = session.Channel.Name;
            e.From = session.Channel.EndPoint.ToString();
            foreach (Beetle.Express.IChannel other in session.Application.Server.GetOnlines())
            {
                if (other != session.Channel)
                    session.Application.Server.Send(e, other);
            }
        }
    }
    public class AppModel : EC.IAppModel
    {
        public void Init(EC.IApplication application)
        {
            application.Disconnected += (o, e) =>
            {
                Beetle.Express.IChannel channel = e.Session.Channel;
                Chat.Signout msg = new Signout();
                msg.Name = channel.Name;
                msg.From = channel.EndPoint.ToString();
                foreach (Beetle.Express.IChannel other in application.Server.GetOnlines())
                {
                    if (other != channel)
                        application.Server.Send(msg, other);
                }
            };
        }

        public string Name
        {
            get { return "AppModel"; }
        }

        public string Command(string cmd)
        {
            throw new NotImplementedException();
        }
    }
}
