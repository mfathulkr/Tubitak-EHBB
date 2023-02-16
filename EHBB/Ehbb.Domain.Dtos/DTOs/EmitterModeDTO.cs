using Ehbb.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Dtos.DTOs
{
    public class EmitterModeDTO
    {
        public int EmitterModeID { get; set; }
        public string? EmitterModeName { get; set; }
        public double RFlimits { get; set; }
        public double PRIlimits { get; set; }
        public double PDlimits { get; set; }
        public double ScanLimits { get; set; }
        public int EmitterID { get; set; }
    }
}
