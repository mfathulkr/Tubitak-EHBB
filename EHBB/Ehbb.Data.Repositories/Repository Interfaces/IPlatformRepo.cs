using Ehbb.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Repositories.Repository_Interfaces
{
    public interface IPlatformRepo
    {
        
        Task AddPlatformAsync(Platform entity);
      
        Task DeletePlatformAsync(Platform platform);
        Task AddPlatformEmitter(PlatformEmitter platformEmitter);
        Task DeletePlatformEmitter(PlatformEmitter platformEmitter);

        Task<Platform> GetPlatformByIdAsync(int platformId);
        Task<IEnumerable<Platform>> GetAllPlatformAsync();
        Task<PlatformLaser> GetPlatformLaserElement(int platformLaserId);
        Task<PlatformEmitter> GetPlatformEmitterElement(int platformEmitterId);
        Task <IEnumerable<PlatformLaser>> GetPlatformLaserByIdAsync(int platformId);
        Task<IEnumerable<PlatformLaser>> GetLaserOfPlatformByIdAsync(int laserId);
        Task<IEnumerable<PlatformEmitter>> GetEmitterOfPlatformsByIdAsync(int emitterId);
        Task<IEnumerable<PlatformLaser>> GetAllPlatformLaserAsync();
        Task<IEnumerable<PlatformEmitter>> GetPlatformEmitterByIdAsync(int platformId);
        Task<IEnumerable<PlatformEmitter>> GetAllPlatformEmitterAsync();

        Task AddPlatformLaser(PlatformLaser platformLaser);
        Task DeletePlatformLaser(PlatformLaser platformLaser);
        Task SaveChanges();
    }
}
