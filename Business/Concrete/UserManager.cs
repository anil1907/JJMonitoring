using Business.Abstract.Users;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract.Users;
using Entity.Enums;
using Entity.Models.User;
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
        public User RegisterWithModel(AccountRegisterViewModel model)
        {
            User entity = new User();
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
            entity.BranchId = model.BranchId;
            entity.UserRole = (UserRole)model.UserRole;
            entity.UserName = model.Username;
            var userId = _userDal.Add(entity);
            return _userDal.Get(x => x.Id == userId);


        }

    }
}
