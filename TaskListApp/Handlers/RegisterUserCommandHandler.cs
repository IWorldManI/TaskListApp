using MediatR;
using TaskListApp.Data;
using TaskListApp.Models.User;
using TaskListApp.Commands;
using TaskListApp.Services;

namespace TaskListApp.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthenticationService _authenticationService;

        public RegisterUserCommandHandler(ApplicationDbContext context, AuthenticationService authenticationService)
        {
            _context = context;
            _authenticationService = authenticationService;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = request.Password
            };

            var token = _authenticationService.GenerateJwtToken(user);

            user.Token = token;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
