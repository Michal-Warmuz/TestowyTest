using Mediator.Command;
using Mediator.Enums;
using Mediator.Query;
using Microsoft.AspNetCore.Mvc;
using Molly.Infrastructure.Mediator.Base;

namespace MilleniumTest.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IQueryDispatcher _queryDispatcher;
        protected readonly ICommandDispatcher _commandDispatcher;

        public BaseController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        protected IActionResult HandleServiceResult(BaseApiResult serviceResponse) => serviceResponse.ResultCode switch
        {
            ResponseStatus.Ok => Ok(serviceResponse),
            ResponseStatus.ValidationErrors => BadRequest(serviceResponse),
            ResponseStatus.Unauthorized => Unauthorized(serviceResponse),
            ResponseStatus.Forbidden => StatusCode(StatusCodes.Status403Forbidden),
            ResponseStatus.Conflict => Conflict(serviceResponse),
            ResponseStatus.NotFound => NotFound(serviceResponse),
            ResponseStatus.Unknown => BadRequest(serviceResponse),
            ResponseStatus.Created => StatusCode(StatusCodes.Status201Created)
        };
    }
}
