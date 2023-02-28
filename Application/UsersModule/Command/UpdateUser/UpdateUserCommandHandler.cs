using Contract.Repository;
using Domain;
using FluentValidation;
using Mediator.Command;
using Mediator.Enums;
using Microsoft.Extensions.Logging;

namespace UsersModule.Command.UpdateUser
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UpdateUserCommand> _validator;
        private readonly ILogger _logger;

        public UpdateUserCommandHandler(IUserRepository userRepository, IValidator<UpdateUserCommand> validator, ILogger<UpdateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<CommandResult> Handle(UpdateUserCommand command, CancellationToken cancellation)
        {
            var resultValid = _validator.Validate(command);

            if (!resultValid.IsValid)
            {
                _logger.LogInformation("Not valid user");
                return new CommandResult(ResponseStatus.ValidationErrors, error: string.Join(',', resultValid.Errors));
            }

            var user = await _userRepository.GetByIdAsync(command.Id);

            if(user == null)
            {

                _logger.LogInformation("Success add user");
                user = new User(command.Login, command.Password);

                await _userRepository.AddAsync(user);

                return new CommandResult(ResponseStatus.Ok);
            }

            user.Login = command.Login; 
            user.Password = command.Password;

            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("Success update user");

            return new CommandResult(ResponseStatus.Ok);
        }
    }
}
