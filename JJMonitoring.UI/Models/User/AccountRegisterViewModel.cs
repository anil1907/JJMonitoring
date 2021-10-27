using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JJMonitoring.UI.Models.User
{
    public class AccountRegisterViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RetryPassword { get; set; }
        public UserRole UserRole { get; set; }

    }
}
