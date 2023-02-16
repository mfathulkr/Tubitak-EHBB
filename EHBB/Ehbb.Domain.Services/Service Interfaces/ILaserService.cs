using Ehbb.Domain.Dtos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Services.Service_Interfaces
{
    public interface ILaserService
    {
        Task<IEnumerable<LaserDTO>> GetAllLaserAsync();
        Task<LaserDTO> GetLaserAsync(int id);
        Task AddLaserAsync(LaserDTO laserThreatsDTO);
        Task UpdateLaserAsync(LaserDTO laserThreatsDTO);
        Task DeleteLaserAsync(int laserId);
        Task<IEnumerable<LaserModeDTO>> GetLaserModesAsync();
        Task<LaserModeDTO> GetLaserModeAsync(int id);
        Task AddLaserModeAsync(LaserModeDTO laserModesDTO);
        Task UpdateLaserModeAsync(LaserModeDTO laserModesDTO);
        Task DeleteLaserModeAsync(int lasermodeid);
    }
}
