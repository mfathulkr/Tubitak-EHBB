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
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator() 
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName is required!");
            RuleFor(x => x.UserName)
                .MaximumLength(50)
                .WithMessage("Username max length is 50");
            RuleFor(user => user.Password)
                .NotEmpty()
                .MinimumLength(9)
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{9,}$")
                .WithMessage("Password must contain at least 9 characters, uppercase and lowercase letters, numbers and special characters");
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Name can not be empty max length is 50");
            RuleFor(x => x.Surname)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Name can not be empty max length is 50");
            RuleFor(x => x.Email)
                .MaximumLength(100)
                .WithMessage("emailmax length 50");
        }

    }
}
