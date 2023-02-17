using Ehbb.Domain.Dtos.DTOs;
using Ehbb.Domain.Services.Service_Interfaces;
using Ehbb.Domain.Services.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ehbb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,EH,Laser")]
    public class LaserController :ControllerBase
    {
        private readonly ILaserService _laserService;
        private readonly ILogger<LaserController> _logger;
        private readonly IValidator<LaserDTO> _laserValidator;
        private readonly IValidator<LaserModeDTO> _laserModeValidator;

        public LaserController(ILaserService laserService, ILogger<LaserController> logger, IValidator<LaserDTO> laserValidator, IValidator<LaserModeDTO> laserModeValidator)
        {
            _laserService = laserService;
            _logger = logger;
            _laserValidator = laserValidator;
            _laserModeValidator = laserModeValidator;
        }

        [HttpGet("Laser")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetLasers()
        {
            try
            {
                var lasers = await _laserService.GetAllLaserAsync();
                return Ok(lasers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting lasers");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpGet("Mode")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetLaserModes()
        {
            try
            {
                var lasermodes = await _laserService.GetLaserModesAsync();
                return Ok(lasermodes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting laser modes");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpGet("Laser/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetLaser(int id)
        {
            try
            {
                var laser = await _laserService.GetLaserAsync(id);
                if (laser == null)
                    return NotFound();
                return Ok(laser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting laser");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpGet("Mode/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetLaserMode(int id)
        {
            try
            {
                var mode = await _laserService.GetLaserModeAsync(id);
                if (mode == null)
                    return NotFound();
                return Ok(mode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting laser mode");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPost("Laser")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AddLaser(LaserDTO laserDTO)
        {
            var validationResult = await _laserValidator.ValidateAsync(laserDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            
            try
            {
                await _laserService.AddLaserAsync(laserDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding laser");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPost("Mode")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AddLaserMode(LaserModeDTO laserModeDTO)
        {
            var validationResult = await _laserModeValidator.ValidateAsync(laserModeDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _laserService.AddLaserModeAsync(laserModeDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding laser mode");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPut("Laser/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateLaser(int id, LaserDTO laserDTO)
        {
            var validationResult = await _laserValidator.ValidateAsync(laserDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            
            if (id != laserDTO.LaserID)
                return BadRequest();

            try
            {
                await _laserService.UpdateLaserAsync(laserDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating laser");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpPut("Mode/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateLaserMode(int id, LaserModeDTO laserModeDTO)
        {
            var validationResult = await _laserModeValidator.ValidateAsync(laserModeDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (id != laserModeDTO.LaserModeID)
                return BadRequest();

            try
            {
                await _laserService.UpdateLaserModeAsync(laserModeDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating laser mode");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpDelete("Laser")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteLaser(LaserDTO laserDTO)
        {
            var validationResult = await _laserValidator.ValidateAsync(laserDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            
            try
            {
                await _laserService.DeleteLaserAsync(laserDTO.LaserID);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting laser");
                return BadRequest();
            }
        }

        [HttpDelete("Mode")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteLaserMode(LaserModeDTO laserModeDTO)
        {
            var validationResult = await _laserModeValidator.ValidateAsync(laserModeDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _laserService.DeleteLaserModeAsync(laserModeDTO.LaserModeID);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting laser mode");
                return BadRequest();
            }
        }
    }
}
