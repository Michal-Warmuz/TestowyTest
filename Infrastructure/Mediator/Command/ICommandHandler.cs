namespace Mediator.Command
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<CommandResult> Handle(TCommand command, CancellationToken cancellation);
    }


    public interface ICommandHandler<in TCommand, TCommandResul> where TCommand : ICommand
    {
        Task<CommandResult<TCommandResul>> Handle(TCommand command, CancellationToken cancellation);
    }
}
