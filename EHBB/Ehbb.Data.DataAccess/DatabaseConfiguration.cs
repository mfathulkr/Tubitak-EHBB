using Ehbb.Data.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.DataAccess
{
    public static class DatabaseConfiguration
    {
        public static void AddEhbbDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("EhbbConnStr"));
            });
            services.AddDbContext<PlatformDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("EhbbConnStr"));
            });
            services.AddDbContext<SessionDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("EhbbConnStr"));
            });
        }
    }
}
