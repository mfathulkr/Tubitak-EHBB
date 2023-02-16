using Ehbb.Data.DataAccess.Configuration_Interfaces;
using Ehbb.Data.Entities.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Ehbb.Data.DataAccess.Contexts
{
    public class UserDbContext : DbContext
    {
        private readonly IEnumerable<IUserConfiguration> _configuration;

        public UserDbContext(DbContextOptions<UserDbContext> options, IEnumerable<IUserConfiguration> configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoleAssocs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _configuration.ToList().ForEach(v => v.Configure(modelBuilder));
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    UserName = "admin",
                    Name = "admin",
                    Surname = "admin",
                    Email = "admin@admin",
                    Password = "Admin_999"
                }
            );
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleID = 1,
                    RoleName = Entities.Enums.ERoleName.Admin
                }
            );
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserRoleID = 1,
                    UserID = 1,
                    RoleID = 1,
                }
            );

        }
    }
}
