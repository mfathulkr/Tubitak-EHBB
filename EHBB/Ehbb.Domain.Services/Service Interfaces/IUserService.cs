using Ehbb.Domain.Dtos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Services.Service_Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserAsync(int id);
        Task AddUserAsync(UserDTO userDTO);
        Task UpdateUserAsync(UserDTO userDTO);
        Task DeleteUserAsync(UserDTO userDTO);
        Task<IEnumerable<RoleDTO>> GetRolesAsync();
        Task<RoleDTO> GetRoleAsync(int id);
        Task AddRoleAsync(RoleDTO roleDTO);
        Task UpdateRoleAsync(RoleDTO roleDTO);
        Task DeleteRoleAsync(RoleDTO roleDTO);
        Task AddRoleToUser(UserRoleDTO userRoleDTO);
        Task<IEnumerable<UserRoleDTO>> GetUserRoles(int userId);
        Task<IEnumerable<UserRoleDTO>> GetUserRoles();
        Task UpdateUserRole(UserRoleDTO userRoleDTO);
        Task DeleteUserRole(UserRoleDTO userRoleDTO);
        Task <UserDTO> GetByUserNamePassword (int userId);
    }
}
