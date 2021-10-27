using Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract.Users
{
    public interface IUserService
    {
        User Login(string userName, string password);
    }
}
