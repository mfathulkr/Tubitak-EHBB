using AutoMapper.Configuration.Annotations;
using AutoMapper.Execution;
using Ehbb.Domain.Dtos.DTOs;
using Ehbb.Domain.Services.Service_Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ehbb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,EH")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _platformService;
        private readonly ILogger<PlatformController> _logger;
        private readonly IValidator<PlatformDTO> _platformValidator;

        public PlatformController(IPlatformService platformService, ILogger<PlatformController> logger, IValidator<PlatformDTO> platformValidator)
        {
            _platformService = platformService;
            _logger = logger;
            _platformValidator = platformValidator;
        }

        [HttpGet("Platform")]
        public async Task<IActionResult> GetPlatforms()
        {
            try
            {
                var plats = await _platformService.GetAllPlatformsAsync();
                return Ok(plats);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while getting platforms.");
                return StatusCode(500, "Something went Wrong!");
            }
        }
        [HttpGet("Platform/{id}")]
        public async Task<IActionResult> GetPlatform(int id)
        {
            try
            {
                var plat = await _platformService.GetPlatformByIdAsync(id);
                return Ok(plat);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while getting the platform.");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpPost("Platform")]
        public async Task<IActionResult> AddPlatform(PlatformDTO platformDTO)
        {
            var validationResult = await _platformValidator.ValidateAsync(platformDTO);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            try
            {
                await _platformService.AddPlatformAsync(platformDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding platform");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpPut("Platform")]
        public async Task<IActionResult> UpdatePlatform(int platId, PlatformDTO platformDTO)
        {
            var validationResult = await _platformValidator.ValidateAsync(platformDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (platId != platformDTO.PlatformID)
                return BadRequest();
            try
            {
                await _platformService.UpdatePlatformAsync(platformDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating platform");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpDelete("Platform")]
        public async Task<IActionResult> DeletePlatform(PlatformDTO platformDTO)
        {
            var validationResult = await _platformValidator.ValidateAsync(platformDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _platformService.DeletePlatformAsync(platformDTO.PlatformID);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting platform");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpGet("PlatformEmitter")]
        public async Task<IActionResult> GetAllPlatformEmitterElements()
        {
            try
            {
                var platemit = await _platformService.GetAllPlatformEmittersAsync();
                return Ok(platemit);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while getting platform-emitter elements!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpGet("PlatformEmitter/{platformId}")]
        public async Task<IActionResult> GetAllEmittersByPlatformId(int platformId)
        {
            try
            {
                var platemit = await _platformService.GetAllPlatformEmittersByIdAsync(platformId);
                return Ok(platemit);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while getting emitters of the platform!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpPost("PlatformEmitter")]
        public async Task<IActionResult> AddPlatformEmitterElement(PlatformEmitterDTO platformEmitterDTO)
        {
            try
            {
                await _platformService.AddPlatformEmitterAsync(platformEmitterDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while adding PlatformEmitter Element!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpDelete("PlatformEmitter")]
        public async Task<IActionResult> DeletePlatformEmitterAsync(PlatformEmitterDTO platformEmitterDTO)
        {
            try
            {
                await _platformService.DeletePlatformEmitterElement(platformEmitterDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting platform emitter element!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpDelete("PlatformEmitter/{platformId}")]
        public async Task<IActionResult> DeleteElementsIncludePlatformForPlatformEmitter(int platformId)
        {
            try
            {
                await _platformService.DeletePlatformOfEmitterAsync(platformId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting elements that include the platform!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpDelete("PlatformEmitter/{emitterId}")]
        public async Task<IActionResult> DeleteElementsIncludeEmitter(int emitterId)
        {
            try
            {
                await _platformService.DeleteEmitterOfPlatformAsync(emitterId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting elements that include the emitter!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpPut("PlatformEmitter")]
        public async Task<IActionResult> UpdatePlatformEmitter(PlatformEmitterDTO platformEmitterDTO)
        {
            try
            {
                await _platformService.UpdatePlatformEmitterAsync(platformEmitterDTO);
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occured while updating PlatformEmitter!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpGet("PlatformLaser")]
        public async Task<IActionResult> GetAllPlatformLasersElements()
        {
            try
            {
                var platlaser = await _platformService.GetAllPlatformLaserAsync();
                return Ok(platlaser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while getting platformlaser elements!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpGet("PlatformLaser/{platformId}")]
        public async Task<IActionResult> GetAllLasersByPlatformId(int platformId)
        {
            try
            {
                var platlaser = await _platformService.GetAllPlatformLaserByIdAsync(platformId);
                return Ok(platlaser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while getting laser of the platform!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpPost("PlatformLaser")]
        public async Task<IActionResult> AddPlatformLaserElement(PlatformLaserDTO platformLaserDTO)
        {
            try
            {
                await _platformService.AddPlatformLaserAsync(platformLaserDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while adding PlatformLaser Element!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpDelete("PlatformLaser")]
        public async Task<IActionResult> DeletePlatformLaserAsync(PlatformLaserDTO platformLaserDTO)
        {
            try
            {
                await _platformService.DeletePlatformLaserElement(platformLaserDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting platform laser element!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpDelete("PlatformLaser/{platformId}")]
        public async Task<IActionResult> DeleteElementsIncludePlatformForPlatformLaser(int platformId)
        {
            try
            {
                await _platformService.DeletePlatformOfLaserAsync(platformId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting elements that include the platform!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpDelete("PlatformLaser/{laserId}")]
        public async Task<IActionResult> DeleteElementsIncludeLaser(int laserId)
        {
            try
            {
                await _platformService.DeleteLaserOfPlatformAsync(laserId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting elements that include laser!");
                return StatusCode(500, "Something went wrong!");
            }
        }
        [HttpPut("PlatformLaser")]
        public async Task<IActionResult> UpdatePlatformLaser(PlatformLaserDTO platformLaserDTO)
        {
            try
            {
                await _platformService.UpdatePlatformLaserAsync(platformLaserDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while updating PlatformLaser!");
                return StatusCode(500, "Something went wrong!");
            }
        }
    }
}

