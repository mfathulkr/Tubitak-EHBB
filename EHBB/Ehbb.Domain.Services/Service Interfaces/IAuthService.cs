using Ehbb.Data.Entities.Entities;
using Ehbb.Domain.Dtos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Services.Service_Interfaces
{
    public interface IAuthService
    {
        Task<UserDTO> IsPresentAsync(LoginDTO request);
        Task<RoleDTO> GetRolesAsync(UserDTO userDTO);
        Task AddSession(LoginDTO request, string token);
        Task<Session> GetSessionAsync(string token);
        Task<Session> GetSessionByOwnerAsync(string username);
        Task DeleteSession(string token);
        Task UpdateSession(Session session, string refreshtoken, DateTime created, DateTime expires);
    }
}
