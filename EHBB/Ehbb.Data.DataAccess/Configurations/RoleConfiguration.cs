using Ehbb.Data.DataAccess.Configuration_Interfaces;
using Ehbb.Data.Entities.Entities;
using Ehbb.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.DataAccess.Configurations
{
    public class RoleConfiguration : IUserConfiguration
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleID);
                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasConversion(
                        v => v.ToString(),
                        v => (ERoleName)Enum.Parse(typeof(ERoleName), v))
                    .IsRequired();
            });
        }
    }
}
