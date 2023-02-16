using Ehbb.Domain.Dtos.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.Validation.Validators
{
    public class PlatformValidator : AbstractValidator<PlatformDTO>
    {
        public PlatformValidator()
        {
            RuleFor(x => x.PlatformName)
                .MaximumLength(50)
                .WithMessage("Platform max length is 50.");
            RuleFor(x => x.Remarks)
                .MaximumLength(400)
                .WithMessage("Remarks max length is 400");
            RuleFor(x => x.DateCreated)
                .NotEmpty();
            RuleFor(x => x.DateLastUpdated)
                .NotEmpty();
            RuleFor(x => x.Length)
                .NotEmpty();
            RuleFor(x => x.Width)
                .NotEmpty();
            RuleFor(x => x.Height)
                .NotEmpty();
            RuleFor(x => x.Weight)
                .NotEmpty();
            RuleFor(x => x.MaxSpeed)
                .NotEmpty();
            RuleFor(x => x.MinSpeed)
                .NotEmpty();
            RuleFor(x => x.Latitude)
                .NotEmpty();
            RuleFor(x => x.Longitude)
                .NotEmpty();
        }
    }
}
