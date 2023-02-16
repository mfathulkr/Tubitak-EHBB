using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Entities.Entities
{
    public class PlatformLaser
    {
        public int PlatformLaserID { get; set; }
        public int PlatformID { get; set; }
        public Platform Platform { get; set; }
        public int LaserID { get; set; }
        public Laser Laser { get; set; }

    }
}
