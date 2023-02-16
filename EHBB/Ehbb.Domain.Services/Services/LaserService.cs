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
    public class LaserService : ILaserService
    {
        private readonly ILaserRepo _laserRepo;
        private readonly IMapper _mapper;

        public LaserService(ILaserRepo laserRepo, IMapper mapper)
        {
            _laserRepo = laserRepo;
            _mapper = mapper;
        }

        public async Task AddLaserModeAsync(LaserModeDTO laserModesDTO)
        {
            var mode = _mapper.Map<LaserMode>(laserModesDTO);
            await _laserRepo.AddLaserModeAsync(mode);
            await _laserRepo.SaveChanges();
        }

        public async Task AddLaserAsync(LaserDTO laserThreatsDTO)
        {
            var laser = _mapper.Map<Laser>(laserThreatsDTO);
            await _laserRepo.AddLaserAsync(laser);
            await _laserRepo.SaveChanges();
        }

        public async Task DeleteLaserModeAsync(int lasermodeid)
        {
            var mode = await _laserRepo.GetLaserModeByIdAsync(lasermodeid);
            if(mode == null)
            {
                throw new Exception("Laser Mode Not Found!");
            }
            await _laserRepo.DeleteLaserModeAsync(mode);
            await _laserRepo.SaveChanges();
        }

        public async Task DeleteLaserAsync(int laserId)
        {
            var laser = await _laserRepo.GetLaserByIdAsync(laserId);
            if (laser == null)
                throw new Exception("Laser Not Found!");

            await _laserRepo.DeleteLaserAsync(laser);
            await _laserRepo.SaveChanges();
        }

        public async Task<LaserModeDTO> GetLaserModeAsync(int id)
        {
            var mode = await _laserRepo.GetLaserModeByIdAsync(id);
            var modeDto = _mapper.Map<LaserModeDTO>(mode);
            return modeDto;
        }

        public async Task<IEnumerable<LaserModeDTO>> GetLaserModesAsync()
        {
            var modes = await _laserRepo.GetAllLaserModeAsync();
            var modeDtos = _mapper.Map<IEnumerable<LaserModeDTO>>(modes);
            return modeDtos;
        }

        public async Task<IEnumerable<LaserDTO>> GetAllLaserAsync()
        {
            var lasers = await _laserRepo.GetAllLaserAsync();
            var laserDtos = _mapper.Map<IEnumerable<LaserDTO>>(lasers);
            return laserDtos;
        }

        public async Task<LaserDTO> GetLaserAsync(int id)
        {
            var laser = await _laserRepo.GetLaserByIdAsync(id);
            var userDto = _mapper.Map<LaserDTO>(laser);
            return userDto;
        }

        public async Task UpdateLaserModeAsync(LaserModeDTO laserModesDTO)
        {
            var mode = await _laserRepo.GetLaserModeByIdAsync(laserModesDTO.LaserModeID);

            if (mode == null)
            {
                throw new Exception("Laser Not Found");
            }
            mode = _mapper.Map<LaserMode>(laserModesDTO);
            await _laserRepo.SaveChanges();
        }

        public async Task UpdateLaserAsync(LaserDTO laserThreatsDTO)
        {
            var laser = await _laserRepo.GetLaserByIdAsync(laserThreatsDTO.LaserID);

            if (laser == null)
            {
                throw new Exception("Laser Not Found");
            }
            laser = _mapper.Map<Laser>(laserThreatsDTO);
            await _laserRepo.SaveChanges();
        }
    }
}
