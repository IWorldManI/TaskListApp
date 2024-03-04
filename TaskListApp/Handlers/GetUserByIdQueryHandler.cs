using MediatR;
using TaskListApp.Data;
using TaskListApp.Models.User;
using TaskListApp.Services;
using TaskListApp.Queries;

namespace TaskListApp.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthenticationService _authenticationService;

        public GetUserByIdQueryHandler(ApplicationDbContext context, AuthenticationService authenticationService)
        {
            _context = context;
            _authenticationService = authenticationService;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            var user = await _context.Users.FindAsync(request.Id);
            return user;
        }
    }
}