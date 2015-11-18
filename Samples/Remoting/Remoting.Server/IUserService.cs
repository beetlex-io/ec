using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remoting.Service
{
    public interface IUserService
    {
        User Register(string name, string email);
    }
}
