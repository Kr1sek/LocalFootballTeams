using FluentValidation;
using LocalFootballTeam.Migrations;
using LocalFootballTeam.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LocalFootballTeam.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(DbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password).MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var isUsed = dbContext.Users.Any(u => u.Email == value);
                if (isUsed)
                {
                    context.AddFailure("Email", "This email is used");
                }
            });
        }
    }
}
