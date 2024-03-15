using MediatR;
using TaskListApp.Database.Models.UserModel;
using TaskListApp.Services.UserService;

namespace TaskListApp.Handlers.UserHandlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly IUserService _userService;

        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUsersAsync(request);
        }
    }
}