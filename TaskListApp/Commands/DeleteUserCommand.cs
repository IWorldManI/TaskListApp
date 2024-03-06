using MediatR;
using TaskListApp.Database.Models.User;

namespace TaskListApp.Commands
{
    public class DeleteUserCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}