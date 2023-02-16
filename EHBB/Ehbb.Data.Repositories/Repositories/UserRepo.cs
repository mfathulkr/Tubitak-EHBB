using Ehbb.Data.DataAccess.Contexts;
using Ehbb.Data.Entities.Entities;
using Ehbb.Data.Repositories.Repository_Interfaces;
using Ehbb.Domain.Dtos.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Repositories.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly UserDbContext _context;

        public UserRepo(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUserAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
        }

        public async Task DeleteUserAsync(User entity)
        {
            _context.Users.Remove(entity);
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.RoleID == id);
        }

        public async Task<IEnumerable<Role>> GetAllRoleAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task AddRoleAsync(Role entity)
        {
            await _context.Roles.AddAsync(entity);
        }

        public async Task DeleteRoleAsync(Role entity)
        {
            _context.Roles.Remove(entity);
        }

        public async Task AddUserRole(UserRole entity)
        {
            await _context.UserRoleAssocs.AddAsync(entity);
        }

        public async Task<IEnumerable<UserRole>> GetUserRoles(int userId)
        {
            return await _context.UserRoleAssocs.Where(ur => ur.UserID == userId).ToListAsync();
        }

        public async Task<IEnumerable<UserRole>> GetUserRoles()
        {
            return await _context.UserRoleAssocs.ToListAsync();
        }

        public async Task DeleteUserRole(UserRole entity)
        {
            _context.UserRoleAssocs.Remove(entity);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<UserRole> GetUserRoleElementById(int userRoleId)
        {
            return await _context.UserRoleAssocs.FirstOrDefaultAsync(ur => ur.UserRoleID == userRoleId);
        }

        public async Task<User> GetUserByUserNamePassword(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }
    }
}
