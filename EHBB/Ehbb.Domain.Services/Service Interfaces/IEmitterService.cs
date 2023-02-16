using Ehbb.Domain.Dtos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Services.Service_Interfaces
{
    public interface IEmitterService
    {
        Task<IEnumerable<EmitterDTO>> GetAllEmitterAsync();
        Task<EmitterDTO> GetEmitterAsync(int id);
        Task AddEmitterAsync(EmitterDTO emittersDTO);
        Task UpdateEmitterAsync(EmitterDTO emittersDTO);
        Task DeleteEmitterAsync(int emitterid);
        Task<IEnumerable<EmitterModeDTO>> GetEmitterModesAsync();
        Task<EmitterModeDTO> GetEmitterModeAsync(int id);
        Task AddEmitterModeAsync(EmitterModeDTO emitterModesDTO);
        Task UpdateEmitterModeAsync(EmitterModeDTO emitterModesDTO);
        Task DeleteEmitterModeAsync(int emittermodeid);
    }
}
