using Mediator.Command;

namespace UsersModule.Command.UpdateUser
{
    public record UpdateUserCommand : ICommand
    {
        public required long Id { get; init; }
        public required string Login { get; init; }
        public required string Password { get; init; }
    }
}
