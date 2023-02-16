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
    public class PlatformConfiguration : IPlatformConfiguration
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>(entity =>
            {
                entity.HasKey(p => p.PlatformID);
                entity.Property(p => p.PlatformName)
                        .HasMaxLength(50);
                entity.Property(p => p.PlatformType)
                    .HasConversion(
                        v => v.ToString(),
                        v => (EPlatformType)Enum.Parse(typeof(EPlatformType), v));
                entity.Property(p => p.PlatformCategory)
                    .HasConversion(
                        v => v.ToString(),
                        v => (EPlatformCategory)Enum.Parse(typeof(EPlatformCategory), v));
                entity.Property(p => p.DateCreated)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()")
                        .IsRequired();
                entity.Property(p => p.DateLastUpdated)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()")
                        .IsRequired();
                entity.Property(p => p.Length)
                        .IsRequired();
                entity.Property(p => p.Width)
                        .IsRequired();
                entity.Property(p => p.Height)
                        .IsRequired();
                entity.Property(p => p.Weight)
                        .IsRequired();
                entity.Property(p => p.MaxSpeed)
                        .IsRequired();
                entity.Property(p => p.MinSpeed)
                        .IsRequired();
                entity.Property(p => p.Latitude)
                        .HasColumnName("Latitude")
                        .IsRequired();
                entity.Property(p => p.Longitude)
                        .HasColumnName("Longitude")
                        .IsRequired();
            });

        }
    }
}
