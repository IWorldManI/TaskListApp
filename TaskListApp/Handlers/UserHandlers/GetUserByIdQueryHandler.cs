using MediatR;
using TaskListApp.Queries.UserQueries;
using TaskListApp.Database.Models.UserModel;
using TaskListApp.Services.UserService;
using TaskListApp.Services.AuthentificationService;

namespace TaskListApp.Handlers.UserHandlers
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