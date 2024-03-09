using MediatR;
using TaskListApp.Database.Models.TaskListModel;

namespace TaskListApp.Commands.TaskListCommands
{
    public class UpdateTaskListCommand : IRequest<TaskList>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}