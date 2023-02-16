using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Ehbb.Data.Entities.Entities;
using Ehbb.Data.Repositories.Repository_Interfaces;
using Ehbb.Domain.Dtos.DTOs;
using Ehbb.Domain.Services.Service_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepo UserRepo, IMapper mapper)
        {
            _userRepo = UserRepo;
            _mapper = mapper;
        }

        public async Task AddRoleAsync(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            await _userRepo.AddRoleAsync(role);
            await _userRepo.SaveChanges();
        }

        public async Task AddUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _userRepo.AddUserAsync(user);
            await _userRepo.SaveChanges();
        }

        public async Task DeleteRoleAsync(RoleDTO roleDTO)
        {
            var role = await _userRepo.GetRoleByIdAsync(roleDTO.RoleID);
            if (role == null)
            {
                throw new Exception("Role Not Found!");
            }
            await _userRepo.DeleteRoleAsync(role);
            await _userRepo.SaveChanges();
        }

        public async Task DeleteUserAsync(UserDTO userDTO)
        {
            var user = await _userRepo.GetUserByIdAsync(userDTO.UserID);
            if (user == null)
            {
                throw new Exception("User Not Found!");
            }
            await _userRepo.DeleteUserAsync(user);
            await _userRepo.SaveChanges();
        }

        public async Task<RoleDTO> GetRoleAsync(int id)
        {
            var role = await _userRepo.GetRoleByIdAsync(id);
            var roleDto = _mapper.Map<RoleDTO>(role);
            return roleDto;
        }
        public async Task<IEnumerable<RoleDTO>> GetRolesAsync()
        {
            var roles = await _userRepo.GetAllRoleAsync();
            var roleDtos = _mapper.Map<IEnumerable<RoleDTO>>(roles);
            return roleDtos;
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            var user = await _userRepo.GetUserByIdAsync(id);
            var userDto = _mapper.Map<UserDTO>(user);
            return userDto;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await _userRepo.GetAllUserAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDTO>>(users);
            return userDtos;
        }

        public async Task UpdateRoleAsync(RoleDTO roleDTO)
        {
            var role = await _userRepo.GetRoleByIdAsync(roleDTO.RoleID);
            if (role == null)
            {
                throw new Exception("Role Not Found!");
            }
            role = _mapper.Map<Role>(roleDTO);
            await _userRepo.SaveChanges();
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var user = await _userRepo.GetUserByIdAsync(userDTO.UserID);
            if (user == null)
            {
                throw new Exception("User Not Found!");
            }
            user = _mapper.Map<User>(userDTO);
            await _userRepo.SaveChanges();
        }
        public async Task AddRoleToUser(UserRoleDTO userRoleDTO)
        {
            var userRole = _mapper.Map<UserRole>(userRoleDTO);
            await _userRepo.AddUserRole(userRole);
            await _userRepo.SaveChanges();
        }

        public async Task<IEnumerable<UserRoleDTO>> GetUserRoles(int userId)
        {
            var userRoles = await _userRepo.GetUserRoles(userId);
            var urdto = _mapper.Map<IEnumerable<UserRoleDTO>>(userRoles);
            return urdto;
        }
        public async Task<IEnumerable<UserRoleDTO>> GetUserRoles()
        {
            var userRoles = await _userRepo.GetUserRoles();
            var urdtos = _mapper.Map<IEnumerable<UserRoleDTO>>(userRoles);
            return urdtos;
        }
        public async Task UpdateUserRole(UserRoleDTO userRoleDTO)
        {
            var userrole = await _userRepo.GetUserRoleElementById(userRoleDTO.UserRoleID);
            if (userrole == null) { throw new Exception("User Role Not Found!"); }
            userrole = _mapper.Map<UserRole>(userRoleDTO);
            await _userRepo.SaveChanges();
        }
        public async Task DeleteUserRole(UserRoleDTO userRoleDTO)
        {
            var userrole = await _userRepo.GetUserRoles(userRoleDTO.UserID);
            if (userrole == null) { throw new Exception("User Role Not Found!"); }
            foreach (var ur in userrole) await _userRepo.DeleteUserRole(ur);
            await _userRepo.SaveChanges();
        }

        public async Task<UserDTO> GetByUserNamePassword(int userId)
        {
            var user = await _userRepo.GetUserByUserNamePassword(userId);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
