using AutoMapper;
using Ehbb.Data.Entities.Entities;
using Ehbb.Data.Repositories.Repository_Interfaces;
using Ehbb.Domain.Dtos.DTOs;
using Ehbb.Domain.Services.Service_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Services.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public PlatformService(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        public async Task AddPlatformAsync(PlatformDTO platformDto)
        {
            var platform = _mapper.Map<Platform>(platformDto);
            await _platformRepo.AddPlatformAsync(platform);
            await _platformRepo.SaveChanges();
        }

        public async Task AddPlatformEmitterAsync(PlatformEmitterDTO platformEmitterDto)
        {
            var platformemitter = _mapper.Map<PlatformEmitter>(platformEmitterDto);
            await _platformRepo.AddPlatformEmitter(platformemitter);
            await _platformRepo.SaveChanges();
        }

        public async Task AddPlatformLaserAsync(PlatformLaserDTO platformLaserDto)
        {
            var platformlaser = _mapper.Map<PlatformLaser>(platformLaserDto);
            await _platformRepo.AddPlatformLaser(platformlaser);
            await _platformRepo.SaveChanges();
        }

        //emitter silinmiştir, ilişkide oldupu platform-emitter öğelerini siler
        public async Task DeleteEmitterOfPlatformAsync(int emitterId)// parameter has been changed
        {
            var emitterplatform = await _platformRepo.GetEmitterOfPlatformsByIdAsync(emitterId);
            if (emitterplatform == null)
            {
                throw new Exception("Emitter Platform Not Found! You tried to delete an emitter from all the platforms!");
            }
            foreach (var ep in emitterplatform) await _platformRepo.DeletePlatformEmitter(ep);
            await _platformRepo.SaveChanges();
        }

        //laser silinmiştir, ilişkide olduğu platform-laser elementlerini siler
        public async Task DeleteLaserOfPlatformAsync(int laserId)//parameter has been changed
        {
            var laserplatform = await _platformRepo.GetPlatformLaserByIdAsync(laserId);
            if (laserplatform == null) { throw new Exception("Laser Platform Not Found! You tried to delete a laser from all the platforms"); }
            foreach (var lp in laserplatform) await _platformRepo.DeletePlatformLaser(lp);
            await _platformRepo.SaveChanges();
        }

        //platform siler
        public async Task DeletePlatformAsync(int platformId)
        {
            var platform = await _platformRepo.GetPlatformByIdAsync(platformId);
            if (platform == null)
            {
                throw new Exception("Platform Not Found!");
            }
            await _platformRepo.DeletePlatformAsync(platform);
            await _platformRepo.SaveChanges();
        }

        public async Task DeletePlatformEmitterElement(PlatformEmitterDTO platformEmitterDTO)
        {
            var pe = await _platformRepo.GetPlatformEmitterElement(platformEmitterDTO.PlatformEmitterID);
            if (pe == null)
            {
                throw new Exception("PlatformEmitter Not Found!");
            }
            await _platformRepo.DeletePlatformEmitter(pe);
            await _platformRepo.SaveChanges();
        }

        public async Task DeletePlatformLaserElement(PlatformLaserDTO platformLaserDTO)
        {
            var pl = await _platformRepo.GetPlatformLaserElement(platformLaserDTO.PlatformLaserID);
            if (pl == null)
            {
                throw new Exception("PlatformLaser Not Found!");
            }
            await _platformRepo.DeletePlatformLaser(pl);
            await _platformRepo.SaveChanges();
        }

        //platform silinmiştir onun ile birlikte emitterlerini siler
        public async Task DeletePlatformOfEmitterAsync(int platformId)// paramter has been changed
        {
            var platformemitter = await _platformRepo.GetPlatformEmitterByIdAsync(platformId);
            if (platformemitter == null)
            {
                throw new Exception("Platform Emitter Not Found!");
            }
            foreach (var pe in platformemitter) { await _platformRepo.DeletePlatformEmitter(pe); }
            await _platformRepo.SaveChanges();
        }

        //platform silinmiştir onun ile birlikte laserlerini siler
        public async Task DeletePlatformOfLaserAsync(int platformId)//parameter has been changed
        {
            var platformlaser = await _platformRepo.GetPlatformLaserByIdAsync(platformId);
            if (platformlaser == null)
            {
                throw new Exception("Platform Laser Not Found!");
            }
            foreach (var pl in platformlaser) { await _platformRepo.DeletePlatformLaser(pl); }
            await _platformRepo.SaveChanges();
        }

        public async Task<IEnumerable<PlatformEmitterDTO>> GetAllPlatformEmittersAsync()
        {
            var platformEmitters = await _platformRepo.GetAllPlatformEmitterAsync();
            var peDtos = _mapper.Map<IEnumerable<PlatformEmitterDTO>>(platformEmitters);
            return peDtos;
        }

        public async Task<IEnumerable<PlatformEmitterDTO>> GetAllPlatformEmittersByIdAsync(int platformId)
        {
            var platformEmitters = await _platformRepo.GetPlatformEmitterByIdAsync(platformId);
            var peDtos = _mapper.Map<IEnumerable<PlatformEmitterDTO>>(platformEmitters);
            return peDtos;
        }

        public async Task<IEnumerable<PlatformLaserDTO>> GetAllPlatformLaserAsync()
        {
            var platformLasers = await _platformRepo.GetAllPlatformLaserAsync();
            var plDtos = _mapper.Map<IEnumerable<PlatformLaserDTO>>(platformLasers);
            return plDtos;
        }

        public async Task<IEnumerable<PlatformLaserDTO>> GetAllPlatformLaserByIdAsync(int platformId)
        {
            var platformLasers = await _platformRepo.GetPlatformLaserByIdAsync(platformId);
            var plDtos = _mapper.Map<IEnumerable<PlatformLaserDTO>>(platformLasers);
            return plDtos;
        }

        public async Task<IEnumerable<PlatformDTO>> GetAllPlatformsAsync()
        {
            var platform = await _platformRepo.GetAllPlatformAsync();
            var platformDtos = _mapper.Map<IEnumerable<PlatformDTO>>(platform);
            return platformDtos;
        }

        public async Task<PlatformDTO> GetPlatformByIdAsync(int platformId)
        {
            var platform = await _platformRepo.GetPlatformByIdAsync(platformId);
            var platformDto = _mapper.Map<PlatformDTO>(platform);
            return platformDto;
        }

        public async Task UpdatePlatformAsync(PlatformDTO platformDto)
        {
            var platform = await _platformRepo.GetPlatformByIdAsync(platformDto.PlatformID);
            if (platform == null)
            {
                throw new Exception("Platform Not Found!");
            }
            platform = _mapper.Map<Platform>(platformDto);
            await _platformRepo.SaveChanges();
        }

        public async Task UpdatePlatformEmitterAsync(PlatformEmitterDTO platformEmitterDto)
        {
            var platformEmitter = await _platformRepo.GetPlatformEmitterElement(platformEmitterDto.PlatformEmitterID);
            if (platformEmitter == null) { throw new Exception("Platform Emitter Relation Not Found!"); }
            platformEmitter = _mapper.Map<PlatformEmitter>(platformEmitterDto);
            await _platformRepo.SaveChanges();
        }

        public async Task UpdatePlatformLaserAsync(PlatformLaserDTO platformLaserDto)
        {
            var platformLaser = await _platformRepo.GetPlatformLaserElement(platformLaserDto.PlatformLaserID);
            if(platformLaser == null) { throw new Exception("Platform Laser Relation Not Found!"); }
            platformLaser = _mapper.Map<PlatformLaser>(platformLaserDto);
            await _platformRepo.SaveChanges();
        }
    }
}
