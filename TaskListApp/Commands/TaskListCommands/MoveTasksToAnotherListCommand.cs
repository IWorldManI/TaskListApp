using MediatR;
using TaskListApp.Database.Models.TaskListModel;

public class MoveTasksToAnotherListCommand : IRequest<TaskList>
{
    public int SourceListId { get; set; }
    public int TargetListId { get; set; }
}
