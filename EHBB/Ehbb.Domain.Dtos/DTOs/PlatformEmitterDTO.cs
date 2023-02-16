using Ehbb.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Dtos.DTOs
{
    public class PlatformEmitterDTO
    {
        public int PlatformEmitterID { get; set; }
        public int PlatformID { get; set; }
        public int EmitterID { get; set; }
    }
}
