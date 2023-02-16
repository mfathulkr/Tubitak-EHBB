using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Ehbb.Data.DataAccess.Contexts;
using Ehbb.Data.Entities.Entities;
using Ehbb.Domain.Dtos.DTOs;
using Ehbb.Domain.Services.Service_Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly SessionDbContext _context;

        public AuthService(IMapper mapper, IUserService userService, SessionDbContext context)
        {
            _mapper = mapper;
            _userService = userService;
            _context = context;
        }

        public async Task AddSession(LoginDTO request, string token)
        {
            var Session = new Session
            {
                UserName = request.Username,
                Password = request.Password,
                RefreshToken = token,
                Created = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(15),
            };

            await _context.Sessions.AddAsync(Session);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteSession(string token)
        {
            var session = await _context.Sessions.FirstOrDefaultAsync(s => s.RefreshToken == token);
            if (session == null)
            {
                throw new Exception("There is no such a session");
            }

            _context.Sessions.Remove(session);

            await _context.SaveChangesAsync();
        }

        public async Task<RoleDTO> GetRolesAsync(UserDTO userDTO)
        {
            var userroles = await _userService.GetUserRoles(userDTO.UserID);

            var rolesfromget = await _userService.GetRolesAsync();

            var roles = rolesfromget.ToList();

            foreach (var ur in userroles)
            {
                return await _userService.GetRoleAsync(ur.RoleID); 
            }
            return null;
        }

        public async Task<Session> GetSessionAsync(string token)
        {
            return await _context.Sessions.FirstOrDefaultAsync(s => s.RefreshToken == token);
        }

        public async Task<Session> GetSessionByOwnerAsync(string username)
        {
            return await _context.Sessions.FirstOrDefaultAsync(s => s.UserName == username);
        }

        public async Task<UserDTO> IsPresentAsync(LoginDTO loginDTO)
        {
            return await _userService.GetByUserNamePassword(loginDTO.UserID);
        }

        public async Task UpdateSession(Session session, string refreshtoken, DateTime created, DateTime expires)
        {
            var previousSession = _context.Sessions.FirstOrDefault(s => s.SessionID == session.SessionID);

            previousSession.RefreshToken = refreshtoken;
            previousSession.Created = created;
            previousSession.Expires = expires;

            await _context.SaveChangesAsync();
        }
    }
}
