using MediatR;
using TaskListApp.Database.Models.TaskModels;

public class DeleteTaskCommand : IRequest<TaskItem>
{
    public int Id { get; set; }
}