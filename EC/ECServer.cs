using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC
{
    public class ECServer
    {
        public static IApplication Open()
        {
             IApplication app= new Implement.Application();
             app.Open();
             return app;
        }

        public static IApplication Open(int port)
        {
            return Open(null, port);
        }

        public static IApplication Open(string host, int port)
        {
            IApplication application = new Implement.Application();
            application.Host = host;
            application.Port = port;
            application.Open();
            return application;
        }

        public static IApplication Open(string section)
        {
            IApplication app= new Implement.Application(section);
            app.Open();
            return app;
        }
    }
}
