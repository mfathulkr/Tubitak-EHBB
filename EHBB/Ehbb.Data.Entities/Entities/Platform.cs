using Ehbb.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Entities.Entities
{
    public class Platform
    {
        public int PlatformID { get; set; }
        public string PlatformName { get; set; }
        public EPlatformType PlatformType { get; set; }
        public EPlatformCategory PlatformCategory { get; set; }
        public string? Remarks { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double MaxSpeed { get; set; }
        public double MinSpeed { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
