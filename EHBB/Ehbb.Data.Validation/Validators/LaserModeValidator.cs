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
    public class LaserModeValidator : AbstractValidator<LaserModeDTO>
    {
        public LaserModeValidator()
        {
            RuleFor(x => x.LaserModeCode)
                .NotEmpty()
                .MaximumLength(4)
                .WithMessage("Mode code must be 4 char");
            RuleFor(x => x.LaserModeInfo)
                .MaximumLength(5000);
            RuleFor(x => x.LaserModePRI)
                .ExclusiveBetween(0.0, 1000000.0)
                .WithMessage("PRI is between 0-1000000");
            RuleFor(x => x.LaserModePulseDuration)
                .ExclusiveBetween(0.0, 1000000.0)
                .WithMessage("Mode Pulse Duration is between 0-1000000");
            RuleFor(x => x.ScanPeriod)
                .ExclusiveBetween(0.0, 1000.0)
                .WithMessage("Scan Period is between 0-1000");

        }
    }
}
