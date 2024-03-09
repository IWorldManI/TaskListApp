using MediatR;
using TaskListApp.Database.Models.TaskListModel;

namespace TaskListApp.Commands.TaskListCommands
{
    public class CreateTaskListCommand : IRequest<TaskList>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}