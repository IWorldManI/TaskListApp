using MediatR;
using TaskListApp.Models.User;

namespace TaskListApp.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
