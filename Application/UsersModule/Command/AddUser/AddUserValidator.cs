using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersModule.Command.AddUser
{
    internal class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().NotNull().WithMessage("Login is required")
                .MinimumLength(8).WithMessage("Minimum Length equal 8")
                .MaximumLength(30).WithMessage("Maxiumum Length equal 30");
        }
    }
}
