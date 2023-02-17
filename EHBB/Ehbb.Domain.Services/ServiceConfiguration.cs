using Ehbb.Data.Repositories.Repositories;
using Ehbb.Data.Repositories.Repository_Interfaces;
using Ehbb.Domain.Services.Service_Interfaces;
using Ehbb.Domain.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Domain.Services
{
    public static class ServiceConfiguration
    {
        public static void AddEhbbServices(this IServiceCollection services)
        {
            services.AddScoped<IEmitterService, EmitterService>();
            services.AddScoped<ILaserService, LaserService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPlatformService, PlatformService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
