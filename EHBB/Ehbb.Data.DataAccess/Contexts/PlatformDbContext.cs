using Ehbb.Data.DataAccess.Configuration_Interfaces;
using Ehbb.Data.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.DataAccess.Contexts
{
    public class PlatformDbContext : DbContext
    {
        private readonly IEnumerable<IPlatformConfiguration> _platformConfig;
        private readonly IEnumerable<ILaserThreatsConfiguration> _laserConfig;
        private readonly IEnumerable<IEmitterConfiguration> _emitterConfig;


        public PlatformDbContext(DbContextOptions<PlatformDbContext> options, IEnumerable<IPlatformConfiguration> platformConfig, IEnumerable<ILaserThreatsConfiguration> laserConfig, IEnumerable<IEmitterConfiguration> emitterConfig): base(options)
        {
            _platformConfig = platformConfig;
            _laserConfig = laserConfig;
            _emitterConfig = emitterConfig;
        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Laser> Lasers { get; set; }
        public DbSet<LaserMode> LaserModes { get; set; }
        public DbSet<PlatformEmitter> PlatformEmitter { get; set; }
        public DbSet<Emitter> Emitters { get; set; }
        public DbSet<EmitterMode> EmitterModes { get; set; }
        public DbSet<PlatformLaser> PlatformLaser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _platformConfig.ToList().ForEach(v => v.Configure(modelBuilder));
            _laserConfig.ToList().ForEach(v => v.Configure(modelBuilder));
            _emitterConfig.ToList().ForEach(v => v.Configure(modelBuilder));
            base.OnModelCreating(modelBuilder);
        }

    }
}
