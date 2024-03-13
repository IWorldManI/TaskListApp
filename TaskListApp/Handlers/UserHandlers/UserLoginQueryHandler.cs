using MediatR;
using TaskListApp.Queries.UserQueries;
using TaskListApp.Database.Models.UserModel;
using TaskListApp.Services.UserService;

namespace TaskListApp.Handlers.UserHandlers
{
    public class UserLoginQueryHandler : IRequestHandler<LoginQuery, User>
    {
        private readonly IUserService _userService;

        public UserLoginQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await _userService.LoginAsync(request);
        }
    }
}