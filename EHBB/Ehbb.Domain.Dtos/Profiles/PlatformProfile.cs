using AutoMapper;
using Ehbb.Data.Entities.Entities;
using Ehbb.Domain.Dtos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Dtos.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformDTO>().ReverseMap();
            CreateMap<PlatformEmitter, PlatformEmitterDTO>().ReverseMap();
            CreateMap<PlatformLaser, PlatformLaserDTO>().ReverseMap();
        }
    }
}
