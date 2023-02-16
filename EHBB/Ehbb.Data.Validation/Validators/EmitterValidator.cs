using Ehbb.Data.Entities.Entities;
using Ehbb.Domain.Dtos.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ehbb.Data.DataAccess.Validators
{
    public class EmitterValidator : AbstractValidator<EmitterDTO>
    {
        public EmitterValidator(IEnumerable<EmitterDTO> emitterDTO)
        {
            RuleFor(x => x.Notation)
                .MaximumLength(5)
                .WithMessage("notation max 5");
            RuleFor(x => x.EmitterName)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Emitter name is unique can not be empty and max length is 10");
            RuleFor(x => x.SpotNo)
                .NotEmpty()
                .MaximumLength(25)
                .WithMessage("Spot no is unique and canot be empty and max length is 25");
            RuleFor(x => x.EmitterFunction)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("function cannot be empty and and max length is 100");
            RuleFor(x => x.EmitterDescription)
                .MaximumLength(25)
                .WithMessage("description max length is 50");
            
        }
    }
}
