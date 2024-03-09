using MediatR;
using TaskListApp.Database.Models.UserModel;

namespace TaskListApp.Commands.UserCommands
{
    public class RegisterUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
