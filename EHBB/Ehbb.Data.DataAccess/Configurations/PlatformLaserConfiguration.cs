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
    public class PlatformLaserConfiguration : IPlatformConfiguration
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlatformLaser>(entity =>
            {
                entity.HasKey(pl => pl.PlatformLaserID);
            });
        }
    }
}
