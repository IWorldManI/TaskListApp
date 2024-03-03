using TaskListApp.Models.User;

namespace TaskListApp.Services
{
    public interface IUserService
    {
        Task<User> RegisterAsync(UserDto userDto);
        Task<User> LoginAsync(LoginDto loginDto);
        Task<User> GetUserByIdAsync(int id);
        Task<User> UpdateUserAsync(int id, UserDto userDto);
        Task DeleteUser(int id);
    }
}