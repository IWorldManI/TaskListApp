using MediatR;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Commands.TaskCommands
{
    public class CreateTaskCommand : IRequest<TaskItem>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskListId { get; set; }
    }
}