using Ehbb.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Entities.Entities
{
    public class Role
    {
        public int RoleID { get; set; }
        public ERoleName RoleName { get; set; } //this is enum for specific role names

    }
}
