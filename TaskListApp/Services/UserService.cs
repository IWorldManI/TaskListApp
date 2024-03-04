using MediatR;
using TaskListApp.Models.User;
using TaskListApp.Queries;
using TaskListApp.Commands;

namespace TaskListApp.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;

        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<User> RegisterAsync(User userDto)
        {
            var command = new RegisterUserCommand
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.PasswordHash
            };
            return await _mediator.Send(command);
        }

        public async Task<User> LoginAsync(LoginDto loginDto)
        {
            var query = new LoginQuery
            {
                Email = loginDto.Email,
                Password = loginDto.Password
            };
            return await _mediator.Send(query);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var query = new GetUserByIdQuery { Id = id };
            return await _mediator.Send(query);
        }

        public async Task<User> UpdateUserAsync(int id, UserDto userDto)
        {
            var command = new UpdateUserCommand
            {
                Id = id,
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };
            return await _mediator.Send(command);
        }

        public async Task DeleteUser(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);
        }
    }
}