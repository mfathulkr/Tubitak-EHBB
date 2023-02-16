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
    public class EmitterModeConfiguration : IEmitterConfiguration
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmitterMode>(entity =>
            {
                entity.HasKey(e => e.EmitterModeID);
                entity.Property(e => e.EmitterModeName)
                        .HasMaxLength(50)
                        .IsRequired();
                entity.Property(e => e.RFlimits)
                        .IsRequired();
                entity.Property(e => e.PRIlimits)
                        .IsRequired();
                entity.Property(e => e.PDlimits)
                        .IsRequired();
                entity.Property(e => e.ScanLimits)
                        .IsRequired();
                entity.HasOne(e => e.Emitter)
                        .WithMany(r => r.EmitterModes)
                        .HasForeignKey(e => e.EmitterModeID);

            });
        }
    }
}
