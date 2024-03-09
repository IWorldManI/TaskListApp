using MediatR;
using TaskListApp.Database.Models.UserModel;

namespace TaskListApp.Commands.UserCommands
{
    public class DeleteUserCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}