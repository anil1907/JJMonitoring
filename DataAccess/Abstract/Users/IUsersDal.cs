using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Entity.Users;


namespace DataAccess.Abstract.Users
{
    public interface IUsersDal : IEntityRepository<Entity.Users.User>
    {

    }
}
