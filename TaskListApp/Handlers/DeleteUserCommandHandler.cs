using MediatR;
using TaskListApp.Data;
using TaskListApp.Models.User;
using TaskListApp.Commands;
using TaskListApp.Services;

namespace TaskListApp.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthenticationService _authenticationService;

        public DeleteUserCommandHandler(ApplicationDbContext context, AuthenticationService authenticationService)
        {
            _context = context;
            _authenticationService = authenticationService;
        }

        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            var user = await _context.Users.FindAsync(request.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}