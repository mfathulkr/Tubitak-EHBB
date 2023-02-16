using Ehbb.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Repositories.Repository_Interfaces
{
    public interface IUserRepo 
    {
        Task<User> GetUserByIdAsync(int id);
        Task<Role> GetRoleByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<IEnumerable<Role>> GetAllRoleAsync();
        Task AddUserAsync(User entity);
        Task AddRoleAsync(Role entity);
        Task DeleteUserAsync(User entity);
        Task DeleteRoleAsync(Role entity);
        Task AddUserRole(UserRole entity);
        Task<IEnumerable<UserRole>> GetUserRoles();
        Task<IEnumerable<UserRole>> GetUserRoles(int userId);
        Task<UserRole> GetUserRoleElementById(int userRoleId);
        Task DeleteUserRole(UserRole entity);
        Task SaveChanges();
        Task<User> GetUserByUserNamePassword(int userId);
    }
}
