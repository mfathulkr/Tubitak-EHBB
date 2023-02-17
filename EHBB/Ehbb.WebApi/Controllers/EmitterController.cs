using Ehbb.Data.DataAccess.Validators;
using Ehbb.Data.Entities.Entities;
using Ehbb.Domain.Dtos.DTOs;
using Ehbb.Domain.Services.Service_Interfaces;
using Ehbb.Domain.Services.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace Ehbb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,EH,Radar")]
    public class EmitterController : ControllerBase  
    {
        private readonly IEmitterService _emitterService;
        private readonly ILogger<EmitterController> _logger;
        private readonly IValidator<EmitterDTO> _emitterValidator;
        private readonly IValidator<EmitterModeDTO> _emitterModeValidator;

        public EmitterController(IEmitterService emitterService, ILogger<EmitterController> logger, IValidator<EmitterDTO> emitterValidator, IValidator<EmitterModeDTO> emitterModeValidator)
        {
            _emitterService = emitterService;
            _logger = logger;
            _emitterValidator = emitterValidator;
            _emitterModeValidator = emitterModeValidator;
        }

        [HttpGet("Emitter")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEmitters()
        {
            try
            {
                var emitters = await _emitterService.GetAllEmitterAsync();
                return Ok(emitters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting emitters");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpGet("Mode")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEmitterModes()
        {
            try
            {
                var emittermodes = await _emitterService.GetEmitterModesAsync();
                return Ok(emittermodes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting emitter modes");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpGet("Emitter/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEmitter(int id)
        {
            try
            {
                var emitter = await _emitterService.GetEmitterAsync(id);
                if (emitter == null)
                    return NotFound();
                return Ok(emitter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting emitter");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpGet("Mode/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEmitterMode(int id)
        {
            try
            {
                var emittermode = await _emitterService.GetEmitterModeAsync(id);
                if (emittermode == null)
                    return NotFound();
                return Ok(emittermode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting emitter mode");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPost("Emitter")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AddEmitter(EmitterDTO emitterDTO)
        {
            var validationResult = await _emitterValidator.ValidateAsync(emitterDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _emitterService.AddEmitterAsync(emitterDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding emitter");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPost("Mode")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AddEmitterMode(EmitterModeDTO emitterModeDTO)
        {
            var validationResult = await _emitterModeValidator.ValidateAsync(emitterModeDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _emitterService.AddEmitterModeAsync(emitterModeDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding emitter mode");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPut("Emitter/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateEmitter(int id, EmitterDTO emitterDTO)
        {
            var validationResult = await _emitterValidator.ValidateAsync(emitterDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (id != emitterDTO.EmitterID)
                return BadRequest();

            try
            {
                await _emitterService.UpdateEmitterAsync(emitterDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating emitter");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPut("Mode/{id}")]
        [ProducesResponseType(statusCode:(int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateEmitterMode(int id, EmitterModeDTO emitterModeDTO)
        {
            var validationResult = await _emitterModeValidator.ValidateAsync(emitterModeDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (id != emitterModeDTO.EmitterModeID)
                return BadRequest();

            try
            {
                await _emitterService.UpdateEmitterModeAsync(emitterModeDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating emitter mode");
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpDelete("Emitter")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteEmitter(EmitterDTO emitterDTO)
        {
            var validationResult = await _emitterValidator.ValidateAsync(emitterDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _emitterService.DeleteEmitterAsync(emitterDTO.EmitterID);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting emitter");
                return BadRequest();
            }
        }

        [HttpDelete("Mode")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteEmitterMode(EmitterModeDTO emitterModeDTO)
        {
            var validationResult = await _emitterModeValidator.ValidateAsync(emitterModeDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _emitterService.DeleteEmitterModeAsync(emitterModeDTO.EmitterModeID);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting emitter mode");
                return BadRequest();
            }
        }

    }
}
