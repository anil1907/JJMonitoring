using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Models.User
{
    public class AccountRegisterViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RetryPassword { get; set; }
        public int UserRole { get; set; }
        public int BranchId { get; set; }

    }
}
