using Ehbb.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Dtos.DTOs
{
    public class LaserModeDTO
    {
        public int LaserModeID { get; set; }
        public string LaserModeCode { get; set; }
        public string? LaserModeInfo { get; set; }
        public double? LaserModePRI { get; set; }
        public double? LaserModePulseDuration { get; set; }
        public double? ScanPeriod { get; set; }
        public int LaserID { get; set; }
    }
}
