using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.Users;
using DataAccess.Concrete.EntityFramework;
using Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Users
{
    public class EfUsersDal : EfEntityRepositoryBase<User,Context>, IUsersDal
    {

    }
}
