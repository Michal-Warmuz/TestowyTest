using Contract.Repository;
using Domain;
using FluentValidation;
using Mediator.Command;
using Mediator.Enums;
using Microsoft.Extensions.Logging;

namespace UsersModule.Command.AddUser
{
    public class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<AddUserCommand> _validator;
        private readonly ILogger _logger;

        public AddUserCommandHandler(IUserRepository userRepository, IValidator<AddUserCommand> validator, ILogger<AddUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<CommandResult> Handle(AddUserCommand command, CancellationToken cancellation)
        {
            var resultValid = _validator.Validate(command);

            if (!resultValid.IsValid)
            {
                _logger.LogError($" you can't add user");
                return new CommandResult(ResponseStatus.ValidationErrors, error: string.Join(',', resultValid.Errors));
            }

            var user = new User(command.Login, command.Password);

            await _userRepository.AddAsync(user);

            _logger.LogInformation($"Success add user");

            return new CommandResult(ResponseStatus.Created);
        }
    }
}
