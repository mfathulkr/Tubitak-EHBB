using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ehbb.Data.Entities.Entities
{
    public class LaserMode // LaserMode N - 1 LaserThreats
    {
        public int LaserModeID { get; set; }
        public string LaserModeCode { get;set; }            
        public string? LaserModeInfo { get;set; }           
        
        [MaxLength(1000000), MinLength(0)]
        public double? LaserModePRI { get; set; }          
       
        [MaxLength(1000000), MinLength(0)]
        public double? LaserModePulseDuration { get; set; }  
       
        [MaxLength(1000000), MinLength(0)]
        public double? ScanPeriod { get; set; }              
        
        public int LaserID { get; set; }
        public Laser LaserThreat { get;set; }

    }
}
    