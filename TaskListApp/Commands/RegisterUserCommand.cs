using MediatR;
using TaskListApp.Models.User;

namespace TaskListApp.Commands
{
    public class RegisterUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
