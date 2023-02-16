 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Dtos.DTOs
{
    public class LaserDTO
    {
        public int LaserID { get; set; }
        public string LaserName { get; set; }
        public string? SpotNumber { get; set; }
        public double? Weight { get; set; }
        public double? OperatingTemperature { get; set; }
        public double? StorageTemperature { get; set; }
        public double? Power { get; set; }
    }
}
