using Mediator.Command;

namespace UsersModule.Command.DeleteUser
{
    public record DeleteUserCommand : ICommand
    {
        public long Id { get; init; }
    }
}
