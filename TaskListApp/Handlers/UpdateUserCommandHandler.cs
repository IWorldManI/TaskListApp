using MediatR;
using TaskListApp.Data;
using TaskListApp.Models.User;
using TaskListApp.Commands;
using TaskListApp.Services;

namespace TaskListApp.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthenticationService _authenticationService;

        public UpdateUserCommandHandler(ApplicationDbContext context, AuthenticationService authenticationService)
        {
            _context = context;
            _authenticationService = authenticationService;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            var user = await _context.Users.FindAsync(request.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Name = request.Name;
            user.Email = request.Email;
            user.PasswordHash = request.Password;

            await _context.SaveChangesAsync();

            return user;
        }
    }
}