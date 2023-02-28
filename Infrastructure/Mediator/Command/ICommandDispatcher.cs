namespace Mediator.Command
{
    public interface ICommandDispatcher
    {
        Task<CommandResult> Dispatch<TCommand>(TCommand command, CancellationToken cancellation) where TCommand : ICommand;

        Task<CommandResult<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellation) where TCommand : ICommand;
    }
}
