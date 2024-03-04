using MediatR;
using TaskListApp.Queries;
using TaskListApp.Models.User;
using TaskListApp.Services;

namespace TaskListApp.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly IUserService _userService;
        private readonly AuthenticationService _authenticationService;

        public GetUsersQueryHandler(IUserService userService, AuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _userService.GetUsersAsync(request);
        }
    }
}