using Ehbb.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Dtos.DTOs
{
    public class PlatformLaserDTO
    {
        public int PlatformLaserID { get; set; }
        public int PlatformID { get; set; }
        public int LaserID { get; set; }
    }
}
