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
    public class EmitterModeValidator : AbstractValidator<EmitterModeDTO>
    {
        public EmitterModeValidator()
        {
            RuleFor(x => x.EmitterModeName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Mode name cannot be empty and max length is 50");
            RuleFor(x => x.RFlimits)
                .NotEmpty()
                .ExclusiveBetween(0.0, 1000000.0)
                .WithMessage("RF range is 0-100000");
            RuleFor(x => x.PRIlimits)
                .NotEmpty()
                .ExclusiveBetween(0.0, 1000000.0)
                .WithMessage("PRI range is 0-100000");
            RuleFor(x => x.PDlimits)
                .NotEmpty()
                .ExclusiveBetween(0.0, 1000000.0)
                .WithMessage("PD range is 0-100000");
            RuleFor(x => x.ScanLimits)
                .NotEmpty()
                .ExclusiveBetween(0.0, 100000.0)
                .WithMessage("ScanLimits range is 0-10000");
        }
    }
}
