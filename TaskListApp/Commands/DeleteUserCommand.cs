using MediatR;
using TaskListApp.Models.User;

namespace TaskListApp.Commands
{
    public class DeleteUserCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}