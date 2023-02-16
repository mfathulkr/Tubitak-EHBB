using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ehbb.Data.Entities.Entities
{
    public class Emitter
    {
        public int EmitterID { get; set; }
        public string? Notation { get; set; }
        public string EmitterName { get; set; }
        public string SpotNo { get; set; }
        public string EmitterFunction { get; set; }
        public string? EmitterDescription { get; set; }
        
        public ICollection<EmitterMode> EmitterModes { get; set; }
        public int? NumOfModes { get { return EmitterModes.Count; } }

    }
}
