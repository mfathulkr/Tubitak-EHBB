using Ehbb.Domain.Dtos.DTOs;
using Ehbb.Domain.Services.Service_Interfaces;
using Ehbb.Domain.Services.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ehbb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IValidator<UserDTO> _userValidator;
        private readonly IValidator<RoleDTO> _roleValidator;

        public UserController(IUserService userService, ILogger<UserController> logger, IValidator<UserDTO> userValidator, IValidator<RoleDTO> roleValidator)
        {
            _userService = userService;
            _logger = logger;
            _userValidator = userValidator;
            _roleValidator = roleValidator;
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting users");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpGet("User/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUserAsync(id);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting user");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPost("User")]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            var validationResult = await _userValidator.ValidateAsync(userDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _userService.AddUserAsync(userDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding user");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPut("User/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
        {
            var validationResult = await _userValidator.ValidateAsync(userDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (id != userDTO.UserID)
                return BadRequest();

            try
            {
                await _userService.UpdateUserAsync(userDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpDelete("User")]
        public async Task<IActionResult> DeleteUser(UserDTO userDTO)
        {
            var validationResult = await _userValidator.ValidateAsync(userDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _userService.DeleteUserAsync(userDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting user");
                return BadRequest();
            }
        }

        [HttpGet("Role")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _userService.GetRolesAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting roles");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpGet("Role/{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            try
            {
                var role = await _userService.GetRoleAsync(id);
                if (role == null)
                    return NotFound();
                return Ok(role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting role");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPost("Role")]
        public async Task<IActionResult> AddRole(RoleDTO roleDTO)
        {
            var validationResult = await _roleValidator.ValidateAsync(roleDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _userService.AddRoleAsync(roleDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding role");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPut("Role/{id}")]
        public async Task<IActionResult> UpdateRole(int id, RoleDTO roleDTO)
        {
            var validationResult = await _roleValidator.ValidateAsync(roleDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (id != roleDTO.RoleID)
                return BadRequest();

            try
            {
                await _userService.UpdateRoleAsync(roleDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating role");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpDelete("Role")]
        public async Task<IActionResult> DeleteRole(RoleDTO roleDTO)
        {
            var validationResult = await _roleValidator.ValidateAsync(roleDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _userService.DeleteRoleAsync(roleDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting role");
                return BadRequest();
            }
        }

        [HttpGet("UserRole")]
        public async Task<IActionResult> GetUserRoles()
        {
            try
            {
                var userroles = await _userService.GetUserRoles();
                return Ok(userroles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while gettin userroles");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpGet("UserRole/{id}")]
        public async Task<IActionResult> GetUserRolesId(int id)
        {
            try
            {
                var userroles = await _userService.GetUserRoles(id);
                return Ok(userroles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while gettin userrole by id");
                return StatusCode(500, "Something went wrong!");
            }
        }


        [HttpPost("UserRole")]
        public async Task<IActionResult> AddUserRole(UserRoleDTO userRoleDto)
        {
            try
            {
                await _userService.AddRoleToUser(userRoleDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding userrole");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPut("UserRole/{id}")]
        public async Task<IActionResult> UpdateUserRole(int id, UserRoleDTO userRoleDTO)
        {
            if (id != userRoleDTO.UserRoleID)
                return BadRequest();
            try
            {
                await _userService.UpdateUserRole(userRoleDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating userrole");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpDelete("UserRole")]
        public async Task<IActionResult> DeleteUserRole(UserRoleDTO userRoleDTO)
        {
            try
            {
                await _userService.DeleteUserRole(userRoleDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting role");
                return BadRequest();
            }
        }
    }
}
