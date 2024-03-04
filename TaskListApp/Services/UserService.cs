using Microsoft.EntityFrameworkCore;
using TaskListApp.Commands;
using TaskListApp.Data;
using TaskListApp.Models.User;
using TaskListApp.Queries;

namespace TaskListApp.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthenticationService _authenticationService;

        public UserService(ApplicationDbContext context, AuthenticationService authenticationService)
        {
            _context = context;
            _authenticationService = authenticationService;
        }

        public async Task<User> RegisterAsync(RegisterUserCommand command)
        {
            var user = new User
            {
                Name = command.Name,
                Email = command.Email,
                PasswordHash = command.Password
            };

            var token = _authenticationService.GenerateJwtToken(user);

            user.Token = token;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> LoginAsync(LoginQuery command)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == command.Email);
            if (user == null || user.PasswordHash != command.Password)
            {
                throw new Exception("Invalid credentials");
            }

            return user;
        }

        public async Task<User> GetUserByIdAsync(GetUserByIdQuery query)
        {
            _authenticationService.EnsureTokenIsValid();

            var user = await _context.Users.FindAsync(query.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public async Task<User> UpdateUserAsync(UpdateUserCommand command)
        {
            var user = await _context.Users.FindAsync(command.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Name = command.Name;
            user.Email = command.Email;
            user.PasswordHash = command.Password;

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> DeleteUserAsync(DeleteUserCommand command)
        {
            var user = await _context.Users.FindAsync(command.Id);
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
