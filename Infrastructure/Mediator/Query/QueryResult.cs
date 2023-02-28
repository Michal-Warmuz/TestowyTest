using Mediator.Enums;
using Molly.Infrastructure.Mediator.Base;

namespace Mediator.Query
{
    public class QueryResult<T> : BaseApiResult
    {
        public T Payload { get; set; }
        public string? Error { get; set; }


        public QueryResult(ResponseStatus resultCode, T payload, string? error = null) : base(resultCode)
        {
            ResultCode = resultCode;
            Payload = payload;
            Error = error;
        }

        public QueryResult(ResponseStatus resultCode, string? error = null) : base(resultCode)
        {
            ResultCode = resultCode;
            Error = error;
        }
    }
}
