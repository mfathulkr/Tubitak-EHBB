using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ehbb.Data.Entities.Entities
{
    public class Laser // LaserThreats 1 - N LaserMode
    {
        public int LaserID { get; set; }
        public string LaserName { get; set; }               //NO	-	            	VARCHAR / (TEXT)	400 char
        public string? SpotNumber { get; set; }              //NO	-		            VARCHAR? / (TEXT)	5 char
       
        [MaxLength(1000)]
        public double? Weight { get; set; }                  //NO	KILOGRAM	kg  	DOUBLE?	            [0, 1000]
       
        [MaxLength(100), MinLength(-100)]
        public double? OperatingTemperature { get; set; }    //YES	CELSIUS 	oC	    DOUBLE?	            [-100, 100]
       
        [MaxLength(100), MinLength(-100)]
        public double? StorageTemperature { get; set; }      //YES	CELSIUS 	oC	    DOUBLE?	            [-100, 100]
       
        [MaxLength(100000)]
        public double? Power { get; set; }                   //NO	WATT 	    W	    DOUBLE?	            [0, 100000]

        public ICollection<LaserMode>? LaserModes { get; set; }

    }
}
