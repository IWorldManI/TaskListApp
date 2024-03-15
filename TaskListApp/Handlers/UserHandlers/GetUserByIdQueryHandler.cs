using MediatR;
using TaskListApp.Queries.UserQueries;
using TaskListApp.Database.Models.UserModel;
using TaskListApp.Services.UserService;

namespace TaskListApp.Handlers.UserHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserService _userService;

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByIdAsync(request);
        }
    }
}