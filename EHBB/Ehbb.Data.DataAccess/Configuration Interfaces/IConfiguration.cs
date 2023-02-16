using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace Ehbb.Data.DataAccess.Configuration_Interfaces
{
    public interface IConfiguration
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
