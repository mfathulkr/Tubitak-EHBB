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
    public class EmitterProfile : Profile
    {
        public EmitterProfile()
        {
            CreateMap<Emitter, EmitterDTO>().ReverseMap();
            CreateMap<EmitterMode, EmitterModeDTO>().ReverseMap();
        }
    }
}
