using Business.Abstract.Users;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract.Users;
using Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUsersDal _userDal;

        public UserManager(IUsersDal usersDal)
        {
            _userDal = usersDal; 
        }

        public User Login(string userName, string password)
        {
            User user = _userDal.Get(u => u.UserName.Equals(userName));

            if (user != null)
            {
                var isCorrect = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);

                if (isCorrect)
                    return user;

                return null;
            }
            else
            {
                return null;
            }

        }
    }
}
