using MediatR;
using TaskListApp.Database.Models.User;
using TaskListApp.Commands;
using TaskListApp.Services;

namespace TaskListApp.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.RegisterAsync(request);
        }
    }
}
