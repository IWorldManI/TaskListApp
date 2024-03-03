using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskListApp.Data;
using TaskListApp.Models;
using TaskListApp.Models.User;

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

        public async Task<User> RegisterAsync(UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = userDto.Password
            };

            var token = _authenticationService.GenerateJwtToken(user);

            user.Token = token;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null || user.PasswordHash != loginDto.Password)
            {
                throw new Exception("Invalid credentials");
            }

            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            await _authenticationService.EnsureTokenIsValidAsync();

            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<User> UpdateUserAsync(int id, UserDto userDto)
        {
            await _authenticationService.EnsureTokenIsValidAsync();

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Name = userDto.Name;
            user.Email = userDto.Email;

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUser(int id)
        {
            await _authenticationService.EnsureTokenIsValidAsync();

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}