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
    public class EmitterRepo : IEmittersRepo
    {
        private readonly PlatformDbContext _context;

        public EmitterRepo(PlatformDbContext context)
        {
            _context = context;
        }

        public async Task AddEmitterAsync(Emitter entity)
        {
            await _context.Emitters.AddAsync(entity);
        }

        public async Task AddEmitterModeAsync(EmitterMode entity)
        {
            await _context.EmitterModes.AddAsync(entity);
        }

        public async Task DeleteEmitter(Emitter entity)
        {
            _context.Emitters.Remove(entity);
        }

        public async Task DeleteEmitterMode(EmitterMode entity)
        {
            _context.EmitterModes.Remove(entity);
        }

        public async Task<IEnumerable<EmitterMode>> GetAllEmitterModesAsync()
        {
            return await _context.EmitterModes.ToListAsync();
        }

        public async Task<IEnumerable<Emitter>> GetAllEmitterAsync()
        {
            return await _context.Emitters.ToListAsync();
        }

        public async Task<Emitter> GetEmitterByIdAsync(int id)
        {
            return await _context.Emitters.FindAsync(id);
        }

        public async Task<EmitterMode> GetEmitterModeByIdAsync(int id)
        {
            return await _context.EmitterModes.FindAsync(id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
