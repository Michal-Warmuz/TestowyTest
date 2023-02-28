using Mediator.Command;
using Mediator.Query;
using Microsoft.AspNetCore.Mvc;
using MilleniumTest.API.Controllers.Base;
using System.Net;
using UsersModule.Command.AddUser;
using UsersModule.Command.DeleteUser;
using UsersModule.Command.UpdateUser;
using UsersModule.Query.GetAllUsers;

namespace MilleniumTest.API.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher) { }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllUsersResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return HandleServiceResult(await _queryDispatcher.Dispatch<GetAllUsersQuery, IEnumerable<GetAllUsersResponse>>(new GetAllUsersQuery(), CancellationToken.None));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUser(long id)
        {
            return HandleServiceResult(await _commandDispatcher.Dispatch(new DeleteUserCommand() { Id = id }, CancellationToken.None));
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            return HandleServiceResult(await _commandDispatcher.Dispatch(command, CancellationToken.None));
        }


        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            return HandleServiceResult(await _commandDispatcher.Dispatch(command, CancellationToken.None));
        }
    }
}
