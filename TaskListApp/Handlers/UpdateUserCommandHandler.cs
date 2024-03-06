using MediatR;
using TaskListApp.Database.Models.User;
using TaskListApp.Commands;
using TaskListApp.Services;
using System.Threading;
using System.Threading.Tasks;

namespace TaskListApp.Handlers
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