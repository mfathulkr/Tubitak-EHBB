using Ehbb.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Repositories.Repository_Interfaces
{
    public interface IEmittersRepo
    {
        Task<Emitter> GetEmitterByIdAsync(int id);
        Task<EmitterMode> GetEmitterModeByIdAsync(int id);
        Task<IEnumerable<Emitter>> GetAllEmitterAsync();
        Task<IEnumerable<EmitterMode>> GetAllEmitterModesAsync();
        Task AddEmitterAsync(Emitter entity);
        Task AddEmitterModeAsync(EmitterMode entity);
        Task DeleteEmitter(Emitter entity);
        Task DeleteEmitterMode(EmitterMode entity);
        Task SaveChanges();
    }
}
