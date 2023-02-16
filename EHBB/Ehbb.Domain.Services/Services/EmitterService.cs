using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Ehbb.Data.Entities.Entities;
using Ehbb.Data.Repositories.Repositories;
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
    public class EmitterService : IEmitterService
    {
        private readonly IEmittersRepo _emitterRepo;
        private readonly IMapper _mapper;

        public EmitterService(IEmittersRepo emitterRepo, IMapper mapper)
        {
            _emitterRepo = emitterRepo;
            _mapper = mapper;
        }

        public async Task AddEmitterAsync(EmitterDTO emittersDTO)
        {
            var emitter = _mapper.Map<Emitter>(emittersDTO);
            await _emitterRepo.AddEmitterAsync(emitter);
            await _emitterRepo.SaveChanges();
        }

        public async Task AddEmitterModeAsync(EmitterModeDTO emitterModesDTO)
        {
            var mode = _mapper.Map<EmitterMode>(emitterModesDTO);
            await _emitterRepo.AddEmitterModeAsync(mode);
            await _emitterRepo.SaveChanges();
        }

        public async Task<EmitterDTO> GetEmitterAsync(int id)
        {
            var emitter = await _emitterRepo.GetEmitterByIdAsync(id);
            var emitterDto = _mapper.Map<EmitterDTO>(emitter);
            return emitterDto;
        }

        public async Task<EmitterModeDTO> GetEmitterModeAsync(int id)
        {
            var mode = await _emitterRepo.GetEmitterModeByIdAsync(id);
            var modeDto = _mapper.Map<EmitterModeDTO>(mode);
            return modeDto;
        }

        public async Task<IEnumerable<EmitterModeDTO>> GetEmitterModesAsync()
        {
            var modes = await _emitterRepo.GetAllEmitterModesAsync();
            var modeDtos = _mapper.Map<IEnumerable<EmitterModeDTO>>(modes);
            return modeDtos;
        }

        public async Task<IEnumerable<EmitterDTO>> GetAllEmitterAsync()
        {
            var emitters = await _emitterRepo.GetAllEmitterAsync();
            var emittersDtos = _mapper.Map<IEnumerable<EmitterDTO>>(emitters);
            return emittersDtos;
        }

        public async Task UpdateEmitterAsync(EmitterDTO emittersDTO)
        {
            var emitter = await _emitterRepo.GetEmitterByIdAsync(emittersDTO.EmitterID);

            if (emitter == null)
            {
                throw new Exception("Emitter Not Found");
            }
            emitter = _mapper.Map<Emitter>(emittersDTO);
            await _emitterRepo.SaveChanges();
        }

        public async Task UpdateEmitterModeAsync(EmitterModeDTO emitterModesDTO)
        {
            var mode = await _emitterRepo.GetEmitterModeByIdAsync(emitterModesDTO.EmitterModeID);
            if(mode == null)
            {
                throw new Exception("Mode Not Found!");
            }
            mode = _mapper.Map<EmitterMode>(mode);
            await _emitterRepo.SaveChanges();
        }

        public async Task DeleteEmitterAsync(int emitterid)
        {
            var emitter = await _emitterRepo.GetEmitterByIdAsync(emitterid);
            if(emitter == null)
            {
                throw new Exception("Emitter Not Found!");
            }
            await _emitterRepo.DeleteEmitter(emitter);
            await _emitterRepo.SaveChanges();
        }

        public async Task DeleteEmitterModeAsync(int emittermodeid)
        {
            var mode = await _emitterRepo.GetEmitterModeByIdAsync(emittermodeid);
            if(mode == null)
            {
                throw new Exception("Mode Not Found!");
            }
            await _emitterRepo.DeleteEmitterMode(mode);
            await _emitterRepo.SaveChanges();
        }
    }
}
