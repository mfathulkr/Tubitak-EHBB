using Ehbb.Data.DataAccess.Contexts;
using Ehbb.Data.Repositories.Repositories;
using Ehbb.Data.Repositories.Repository_Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Repositories
{
    public static class RepositoryConfiguration
    {
        public static void AddEhbbRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<ILaserRepo, LaserRepo>();
            services.AddScoped<IEmittersRepo, EmitterRepo>();
            services.AddScoped<IPlatformRepo, PlatformRepo>();
        }
    }
}
