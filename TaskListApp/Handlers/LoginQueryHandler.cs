using MediatR;
using TaskListApp.Data;
using Microsoft.EntityFrameworkCore;
using TaskListApp.Models.User;
using TaskListApp.Queries;

namespace TaskListApp.Handlers
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, User>
    {
        private readonly ApplicationDbContext _context;

        public LoginQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || user.PasswordHash != request.Password)
            {
                throw new Exception("Invalid credentials");
            }

            return user;
        }
    }
}