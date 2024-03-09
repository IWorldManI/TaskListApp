using MediatR;
using TaskListApp.Database.Models.TaskModels;

public class UpdateTaskCommand : IRequest<TaskItem>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskCurrentStatus Status { get; set; }
}
