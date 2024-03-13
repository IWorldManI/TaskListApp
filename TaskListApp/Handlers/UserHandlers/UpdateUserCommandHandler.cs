using MediatR;
using TaskListApp.Commands.UserCommands;
using TaskListApp.Database.Models.UserModel;
using TaskListApp.Services.UserService;
using TaskListApp.Services.AuthentificationService;

namespace TaskListApp.Handlers.UserHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserService _userService;
        private readonly AuthenticationService _authenticationService;

        public UpdateUserCommandHandler(IUserService userService, AuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _userService.UpdateUserAsync(request);
        }
    }
}