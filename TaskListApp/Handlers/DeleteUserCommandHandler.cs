using MediatR;
using TaskListApp.Commands;
using TaskListApp.Models.User;
using TaskListApp.Services;
using System.Threading;
using System.Threading.Tasks;

namespace TaskListApp.Handlers
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
