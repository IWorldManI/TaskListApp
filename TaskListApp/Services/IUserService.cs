﻿using TaskListApp.Commands;
using TaskListApp.Models.User;
using TaskListApp.Queries;

namespace TaskListApp.Services
{
    public interface IUserService
    {
        Task<User> RegisterAsync(RegisterUserCommand command);
        Task<User> LoginAsync(LoginQuery command);
        Task<User> GetUserByIdAsync(GetUserByIdQuery id);
        Task<User> UpdateUserAsync(UpdateUserCommand command);
        Task<User> DeleteUserAsync(DeleteUserCommand command);
        Task<IEnumerable<User>> GetUsersAsync(int page = 1, int pageSize = 10, string nameFilter = null, string sortBy = null, string sortDirection = "asc");
    }
}