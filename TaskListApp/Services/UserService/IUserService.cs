using TaskListApp.Commands.UserCommands;
using TaskListApp.Database.Models.UserModel;
using TaskListApp.Queries.UserQueries;

namespace TaskListApp.Services.UserService
{
    public interface IUserService
    {
        Task<User> RegisterAsync(RegisterUserCommand command);
        Task<User> LoginAsync(LoginQuery query);
        Task<User> GetUserByIdAsync(GetUserByIdQuery query);
        Task<User> UpdateUserAsync(UpdateUserCommand command);
        Task<User> DeleteUserAsync(DeleteUserCommand command);
        Task<IEnumerable<User>> GetUsersAsync(GetUsersQuery query);
    }
}