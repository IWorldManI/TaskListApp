using MediatR;
using TaskListApp.Commands.UserCommands;
using TaskListApp.Database.Models.UserModel;
using TaskListApp.Services.UserService;

namespace TaskListApp.Handlers.UserHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateUserAsync(request);
        }
    }
}