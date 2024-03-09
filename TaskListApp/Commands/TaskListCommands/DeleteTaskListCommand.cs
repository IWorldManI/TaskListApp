using MediatR;
using TaskListApp.Database.Models.TaskListModel;

namespace TaskListApp.Commands.TaskListCommands
{
    public class DeleteTaskListCommand : IRequest<TaskList>
    {
        public int Id { get; set; }
    }
}
