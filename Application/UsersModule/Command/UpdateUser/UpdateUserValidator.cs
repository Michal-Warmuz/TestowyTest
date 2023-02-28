using FluentValidation;

namespace UsersModule.Command.UpdateUser
{
    internal class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().NotNull().WithMessage("Login is required")
                .MinimumLength(8).WithMessage("Minimum Length equal 8")
                .MaximumLength(30).WithMessage("Maxiumum Length equal 30");
        }
    }
}
