using MediatR;
using TaskListApp.Database.Models.User;
using TaskListApp.Queries;
using TaskListApp.Services;
using System.Threading;
using System.Threading.Tasks;

namespace TaskListApp.Handlers
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, User>
    {
        private readonly IUserService _userService;

        public LoginQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await _userService.LoginAsync(request);
        }
    }
}