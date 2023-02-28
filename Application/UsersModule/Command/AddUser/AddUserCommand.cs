using Mediator.Command;

namespace UsersModule.Command.AddUser
{
    public record class AddUserCommand : ICommand
    {
        public required string Login { get; init; }
        public required string Password { get; init; }
    }
}
