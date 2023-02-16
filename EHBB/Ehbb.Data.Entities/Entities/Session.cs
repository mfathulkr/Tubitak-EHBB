using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Entities.Entities
{
    public class Session
    {
        public int SessionID { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime Created { get; set; } 
        public DateTime Expires { get; set; }
    }
}
