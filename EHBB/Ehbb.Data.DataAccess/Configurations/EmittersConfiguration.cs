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
    public class EmittersConfiguration : IEmitterConfiguration
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emitter>(entity =>
            {
                entity.HasKey(e => e.EmitterID);
                entity.Property(e => e.Notation)
                        .HasMaxLength(5);
                entity.HasIndex(e => e.EmitterName)
                        .IsUnique();
                entity.Property(e => e.EmitterName)
                        .HasMaxLength(100)
                        .IsRequired();
                entity.HasIndex(e => e.SpotNo)
                        .IsUnique();
                entity.Property(e => e.SpotNo)
                        .HasMaxLength(25)
                        .IsRequired();
                entity.Property(e => e.EmitterFunction)
                        .HasMaxLength(100)
                        .IsRequired();
                entity.Property(e => e.EmitterDescription)
                        .HasMaxLength(50);
                entity.Property(e => e.NumOfModes)
                        .IsRequired();

            });
        }
    }
}
