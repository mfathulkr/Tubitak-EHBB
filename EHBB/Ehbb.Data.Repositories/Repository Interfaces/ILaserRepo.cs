using Ehbb.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Repositories.Repository_Interfaces
{
    public interface ILaserRepo
    {
        Task<Laser> GetLaserByIdAsync(int id);
        Task<LaserMode> GetLaserModeByIdAsync(int id);
        Task<IEnumerable<Laser>> GetAllLaserAsync();
        Task<IEnumerable<LaserMode>> GetAllLaserModeAsync();
        Task AddLaserAsync(Laser entity);
        Task AddLaserModeAsync(LaserMode entity);
        Task DeleteLaserAsync(Laser entity);
        Task DeleteLaserModeAsync(LaserMode entity);
        Task SaveChanges();
    }
}
