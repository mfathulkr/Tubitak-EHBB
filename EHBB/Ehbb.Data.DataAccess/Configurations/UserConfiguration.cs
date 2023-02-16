using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ehbb.Data.Entities;
using Ehbb.Data.Entities.Entities;
using Ehbb.Data.DataAccess.Configuration_Interfaces;

namespace Ehbb.Data.DataAccess.Configurations
{
    public class UserConfiguration : IUserConfiguration
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.Password) 
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsRequired();
            });
        }
    }
}
