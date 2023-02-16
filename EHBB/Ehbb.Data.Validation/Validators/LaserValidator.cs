using Ehbb.Data.Entities.Entities;
using Ehbb.Domain.Dtos.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.DataAccess.Validators
{
    public class LaserValidator : AbstractValidator<LaserDTO>
    {
        public LaserValidator()
        {
            RuleFor(x => x.LaserName)
                .NotEmpty()
                .MaximumLength(400)
                .WithMessage("Laser Name required and max length is 400");
            RuleFor(x => x.SpotNumber)
                .MaximumLength(5)
                .WithMessage("Spot Number max length is 5");
            RuleFor(x => x.Weight)
                .ExclusiveBetween(0.0, 1000.0)
                .WithMessage("Weight is between 0-1000");
            RuleFor(x => x.OperatingTemperature)
                .ExclusiveBetween(-100.0, 100.0)
                .WithMessage("Operating temperature is between -100-100");
            RuleFor(x => x.StorageTemperature)
                .ExclusiveBetween(-100.0, 100.0)
                .WithMessage("Storage temperature is between -100-100");
            RuleFor(x => x.Power)
                .ExclusiveBetween(0.0, 100000.0)
                .WithMessage("Power is between 0-100000");
        }
    }
}
