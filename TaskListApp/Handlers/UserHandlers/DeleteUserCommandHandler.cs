using MediatR;
using TaskListApp.Commands.UserCommands;
using TaskListApp.Database.Models.UserModel;
using TaskListApp.Services.UserService;
using TaskListApp.Services.AuthentificationService;

namespace TaskListApp.Handlers.UserHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly IUserService _userService;
        private readonly AuthenticationService _authenticationService;

        public DeleteUserCommandHandler(IUserService userService, AuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _userService.DeleteUserAsync(request);
        }
    }
}
