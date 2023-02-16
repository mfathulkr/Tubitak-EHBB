using Ehbb.Data.DataAccess.Contexts;
using Ehbb.Data.Entities.Entities;
using Ehbb.Data.Repositories.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Repositories.Repositories
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly PlatformDbContext _context;

        public PlatformRepo(PlatformDbContext context)
        {
            _context = context;
        }

        public async Task AddPlatformAsync(Platform entity)
        {
            await _context.Platforms.AddAsync(entity);
        }

        public async Task AddPlatformEmitter(PlatformEmitter platformEmitter)
        {
            await _context.PlatformEmitter.AddAsync(platformEmitter);
        }

        public async Task AddPlatformLaser(PlatformLaser platformLaser)
        {
            await _context.PlatformLaser.AddAsync(platformLaser);
        }

        public async Task DeletePlatformAsync(Platform platform)
        {
            _context.Platforms.Remove(platform);
        }

        public async Task DeletePlatformEmitter(PlatformEmitter platformEmitter)
        {
            _context.PlatformEmitter.Remove(platformEmitter);
        }

        public async Task DeletePlatformLaser(PlatformLaser platformLaser)
        {
            _context.PlatformLaser.Remove(platformLaser);
        }

        public async Task<IEnumerable<Platform>> GetAllPlatformAsync()
        {
            return await _context.Platforms.ToListAsync();
        }

        public async Task<IEnumerable<PlatformEmitter>> GetAllPlatformEmitterAsync()
        {
            return await _context.PlatformEmitter.ToListAsync();
        }

        public async Task<IEnumerable<PlatformLaser>> GetAllPlatformLaserAsync()
        {
            return await _context.PlatformLaser.ToListAsync();
        }

        public async Task<IEnumerable<PlatformEmitter>> GetEmitterOfPlatformsByIdAsync(int emitterId)
        {
            return await _context.PlatformEmitter.Where(pe => pe.EmitterID == emitterId).ToListAsync();
        }

        public async Task<IEnumerable<PlatformLaser>> GetLaserOfPlatformByIdAsync(int laserId)
        {
            return await _context.PlatformLaser.Where(pl => pl.LaserID == laserId).ToListAsync();
        }

        public async Task<Platform> GetPlatformByIdAsync(int platformId)
        {
            return await _context.Platforms.FirstOrDefaultAsync(p => p.PlatformID == platformId);
        }

        public async Task<IEnumerable<PlatformEmitter>> GetPlatformEmitterByIdAsync(int platformId)
        {
            return await _context.PlatformEmitter.Where(pe => pe.PlatformID == platformId).ToListAsync();
        }

        public Task<PlatformEmitter> GetPlatformEmitterElement(int platformEmitterId)
        {
            return _context.PlatformEmitter.FirstOrDefaultAsync( pe => pe.PlatformEmitterID == platformEmitterId);
        }

        public async Task<IEnumerable<PlatformLaser>> GetPlatformLaserByIdAsync(int platformId)
        {
            return await _context.PlatformLaser.Where(pl => pl.PlatformID == platformId).ToListAsync();
        }

        public async Task<PlatformLaser> GetPlatformLaserElement(int platformLaserId)
        {
            return await _context.PlatformLaser.FirstOrDefaultAsync(pl => pl.PlatformLaserID == platformLaserId);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
