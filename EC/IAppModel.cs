using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beetle.Express;

namespace EC
{
    public interface IAppModel
    {


        string Name { get; }

        void Init(IApplication application);

      

        string Command(string cmd);
    }
}
