using Core.Entities;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Users
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public UserRole UserRole { get; set; }
    }
}
