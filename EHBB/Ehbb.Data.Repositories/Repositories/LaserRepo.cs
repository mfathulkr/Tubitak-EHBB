using Ehbb.Data.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ehbb.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ehbb.Data.Repositories.Repository_Interfaces;

namespace Ehbb.Data.Repositories.Repositories
{
    public class LaserRepo : ILaserRepo
    {
        private readonly PlatformDbContext _context;

        public LaserRepo(PlatformDbContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddLaserAsync(Laser entity)
        {
            await _context.Lasers.AddAsync(entity);
        }

        public async Task AddLaserModeAsync(LaserMode entity)
        {
            await _context.LaserModes.AddAsync(entity);
        }

        public async Task DeleteLaserAsync(Laser entity)
        {
            _context.Lasers.Remove(entity);
        }

        public async Task DeleteLaserModeAsync(LaserMode entity)
        {
            _context.LaserModes.Remove(entity);
        }

        public async Task<IEnumerable<Laser>> GetAllLaserAsync()
        {
            return await _context.Lasers.ToListAsync();
        }

        public async Task<IEnumerable<LaserMode>> GetAllLaserModeAsync()
        {
            return await _context.LaserModes.ToListAsync();
        }

        public async Task<Laser> GetLaserByIdAsync(int id)
        {
            return await _context.Lasers.FindAsync(id);
        }

        public async Task<LaserMode> GetLaserModeByIdAsync(int id)
        {
            return await _context.LaserModes.FindAsync(id);
        }

    }
}
