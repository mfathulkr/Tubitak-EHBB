using Ehbb.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Dtos.DTOs
{
    public class EmitterDTO
    {
        public int EmitterID { get; set; }
        public string? Notation { get; set; }
        public string EmitterName { get; set; }
        public string SpotNo { get; set; }
        public string EmitterFunction { get; set; }
        public string? EmitterDescription { get; set; }
        public int? NumOfModes { get; set; }
    }
}
