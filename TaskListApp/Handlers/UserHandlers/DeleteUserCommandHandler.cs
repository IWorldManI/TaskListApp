using MediatR;
using TaskListApp.Commands.UserCommands;
using TaskListApp.Database.Models.UserModel;
using TaskListApp.Services.UserService;

namespace TaskListApp.Handlers.UserHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DeleteUserAsync(request);
        }
    }
}
