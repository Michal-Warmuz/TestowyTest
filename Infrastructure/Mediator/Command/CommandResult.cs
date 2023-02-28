using Mediator.Enums;
using Molly.Infrastructure.Mediator.Base;

namespace Mediator.Command
{
    public class CommandResult : BaseApiResult
    {
        public string? Error { get; set; }

        public CommandResult(ResponseStatus status, string? error = null) : base(status)
        {
            Error = error;
        }
    }

    public class CommandResult<T> : CommandResult
    {
        public T Payload { get; set; }

        public CommandResult(ResponseStatus status, T payload, string? error = null) : base(status, error)
        {
            Payload = payload;
        }
    }
}
