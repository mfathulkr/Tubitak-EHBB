using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Entities.Entities
{

    public class EmitterMode
    {
        public int EmitterModeID { get; set; }
        public string EmitterModeName { get; set; }
        
        [MaxLength(100000), MinLength(0)]
        public double RFlimits { get; set; }
       
        [MaxLength(100000), MinLength(0)]
        public double PRIlimits { get; set; }
       
        [MaxLength(100000), MinLength(0)]
        public double PDlimits { get; set; }
        
        [MaxLength(10000), MinLength(0)]
        public double ScanLimits { get; set; }
       

        public int? EmitterID { get; set; }
        public Emitter? Emitter { get; set; } //will be configured

    }
}
