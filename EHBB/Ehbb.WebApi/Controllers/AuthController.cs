using AutoMapper.Configuration.Annotations;
using AutoMapper.Execution;
using Azure.Core;
using Ehbb.Data.DataAccess.Validators;
using Ehbb.Data.Entities.Entities;
using Ehbb.Domain.Dtos.DTOs;
using Ehbb.Domain.Services.Service_Interfaces;
using Ehbb.Domain.Services.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ehbb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, IAuthService auhthService, IConfiguration configuration)
        {
            _logger = logger;
            _authService = auhthService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO request)
        {
            var userDTO = await _authService.IsPresentAsync(request);

            if (userDTO == null)
            {
                throw new Exception("Info invalid!");
            }

            var roleDTO = await _authService.GetRolesAsync(userDTO);

            string token = CreateToken(userDTO, roleDTO);

            var online = await _authService.GetSessionAsync(token);

            if (online != null)
            {
                await _authService.DeleteSession(token);
                return BadRequest("Already Logged In! You get logged out!!!");
            }

            await _authService.AddSession(request, token);

            var session = await _authService.GetSessionAsync(token);

            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken, session);

            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken(LoginDTO logindto)
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var sessionfromget = _authService.GetSessionByOwnerAsync(logindto.Username);

            var session = sessionfromget.Result;

            if (session.Expires < DateTime.UtcNow)
            {
                return Unauthorized("Token expired.");
            }

            var userDTO = await _authService.IsPresentAsync(logindto);
            var roleDTOs = await _authService.GetRolesAsync(userDTO);

            string token = CreateToken(userDTO, roleDTOs);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken, session);

            return Ok(token);
        }

        [HttpDelete("logout")]
        public async Task<IActionResult> Logout(LoginDTO logindto)
        {
            var userDTO = await _authService.IsPresentAsync(logindto);

            if (userDTO == null)
            {
                return BadRequest("Info invalid!");
            }

            var sessionfromget = _authService.GetSessionByOwnerAsync(logindto.Username);

            var session = sessionfromget.Result;
            
            var token = session.RefreshToken;

            await _authService.DeleteSession(token);

            return NoContent();
        }

        private string CreateToken(UserDTO userDTO, RoleDTO roleDTO)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userDTO.UserName),
                new Claim(ClaimTypes.Role, roleDTO.RoleName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private RefreshTokenDTO GenerateRefreshToken()
        {
            var refreshToken = new RefreshTokenDTO
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.UtcNow.AddMinutes(15),
                Created = DateTime.UtcNow
            };

            return refreshToken;
        }

        private async void SetRefreshToken(RefreshTokenDTO newRefreshToken, Session session)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            await _authService.UpdateSession(session, newRefreshToken.Token, newRefreshToken.Created, newRefreshToken.Expires);
        }

    }
}

