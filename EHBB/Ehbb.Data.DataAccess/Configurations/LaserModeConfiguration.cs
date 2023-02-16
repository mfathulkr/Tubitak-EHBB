using Ehbb.Data.DataAccess.Configuration_Interfaces;
using Ehbb.Data.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.DataAccess.Configurations
{
    //The min-max values of the double data types are configurated manually inside the entity class.

    public class LaserModeConfiguration : ILaserThreatsConfiguration
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LaserMode>(entity =>
            {
                entity.HasKey(e => e.LaserModeID);
                entity.Property(e => e.LaserModeCode)
                        .HasMaxLength(4)
                        .IsRequired();
                entity.Property(e => e.LaserModeInfo)
                        .HasMaxLength(5000);
                entity.Property(e => e.LaserModePRI);
                entity.Property(e => e.LaserModePulseDuration);
                entity.Property(e => e.ScanPeriod);
                entity.HasOne(e => e.LaserThreat)
                        .WithMany(r => r.LaserModes)
                        .HasForeignKey(e => e.LaserID);

            });
        }
    }
}
