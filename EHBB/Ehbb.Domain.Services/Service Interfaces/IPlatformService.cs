using Ehbb.Data.Entities.Entities;
using Ehbb.Domain.Dtos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Services.Service_Interfaces
{
    public interface IPlatformService
    {
        Task<PlatformDTO> GetPlatformByIdAsync(int platformId);
        Task<IEnumerable<PlatformDTO>> GetAllPlatformsAsync();
        Task AddPlatformAsync(PlatformDTO platformDto);
        Task DeletePlatformAsync(int platformId);
        Task UpdatePlatformAsync(PlatformDTO platformDto);


        Task<IEnumerable<PlatformEmitterDTO>> GetAllPlatformEmittersAsync();
        Task<IEnumerable<PlatformEmitterDTO>> GetAllPlatformEmittersByIdAsync(int platformId);

        Task AddPlatformEmitterAsync(PlatformEmitterDTO platformEmitterDto);
        Task DeletePlatformOfEmitterAsync(int platformId);
        Task DeleteEmitterOfPlatformAsync(int emitterId);
        Task UpdatePlatformEmitterAsync(PlatformEmitterDTO platformEmitterDto);


        Task<IEnumerable<PlatformLaserDTO>> GetAllPlatformLaserAsync();
        Task<IEnumerable<PlatformLaserDTO>> GetAllPlatformLaserByIdAsync(int platformId);
        Task AddPlatformLaserAsync(PlatformLaserDTO platformLaserDto);
        Task DeletePlatformOfLaserAsync(int platformId);
        Task DeleteLaserOfPlatformAsync(int laserId);
        Task UpdatePlatformLaserAsync(PlatformLaserDTO platformLaserDto);

        Task DeletePlatformLaserElement(PlatformLaserDTO platformLaserDTO);
        Task DeletePlatformEmitterElement(PlatformEmitterDTO platformEmitterDTO);

    }
}
