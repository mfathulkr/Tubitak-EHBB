using Ehbb.Data.DataAccess.Validators;
using Ehbb.Data.Validation.Validators;
using Ehbb.Domain.Dtos.DTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Validation
{
    public static class ValidatorConfiguration
    {
        public static void AddEhbbValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserDTO>, UserValidator>();
            services.AddTransient<IValidator<LaserModeDTO>, LaserModeValidator>();
            services.AddTransient<IValidator<EmitterModeDTO>, EmitterModeValidator>();
            services.AddTransient<IValidator<EmitterDTO>, EmitterValidator>();
            services.AddTransient<IValidator<LaserDTO>, LaserValidator>();
            services.AddTransient<IValidator<RoleDTO>, RoleValidator>();
            services.AddTransient<IValidator<PlatformDTO>, PlatformValidator>();
        }
    }
}
