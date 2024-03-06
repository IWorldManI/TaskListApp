using MediatR;
using TaskListApp.Database.Models.User;
using TaskListApp.Services;
using TaskListApp.Queries;

namespace TaskListApp.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserService _userService;
        private readonly AuthenticationService _authenticationService;

        public GetUserByIdQueryHandler(IUserService userService, AuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _userService.GetUserByIdAsync(request);
        }
    }
}