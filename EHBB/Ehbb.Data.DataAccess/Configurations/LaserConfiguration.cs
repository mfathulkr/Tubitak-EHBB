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
    public class LaserConfiguration : ILaserThreatsConfiguration
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laser>(entity =>
            {
                entity.HasKey(e => e.LaserID);
                entity.Property(e => e.LaserName)
                        .HasMaxLength(400)
                        .IsRequired();
                entity.Property(e => e.SpotNumber)
                        .HasMaxLength(5);
                entity.Property(e => e.Weight);
                entity.Property(e => e.OperatingTemperature);
                entity.Property(e => e.StorageTemperature);
                entity.Property(e => e.Power);
            });
        }
    }
}
