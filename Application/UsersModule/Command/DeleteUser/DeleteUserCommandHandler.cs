using Contract.Repository;
using Mediator.Command;
using Mediator.Enums;
using Microsoft.Extensions.Logging;

namespace UsersModule.Command.DeleteUser
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public DeleteUserCommandHandler(IUserRepository userRepository, ILogger<DeleteUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<CommandResult> Handle(DeleteUserCommand command, CancellationToken cancellation)
        {
            var user = await _userRepository.GetByIdAsync(command.Id);

            if(user == null)
            {
                _logger.LogError("User not found");
                return new CommandResult(ResponseStatus.NotFound, error: "User not found");
            }

            await _userRepository.DeleteAsync(user);

            _logger.LogInformation("Success add user");

            return new CommandResult(ResponseStatus.Ok);
        }
    }
}
