using Entity.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class Context : DbContext
    {
        public DbSet<Entity.Users.User> Users { get; set; }
        public DbSet<Entity.Branch.Branch> Branches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigSettings.ConnectionString);
        }
    }
}
