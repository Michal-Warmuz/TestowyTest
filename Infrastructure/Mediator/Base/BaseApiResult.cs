using Mediator.Enums;
using Newtonsoft.Json;

namespace Molly.Infrastructure.Mediator.Base
{
    public abstract class BaseApiResult
    {
        [JsonIgnore]
        public ResponseStatus ResultCode { get; set; }

        public BaseApiResult(ResponseStatus resultCode)
        {
            ResultCode = resultCode;
        }
    }
}
