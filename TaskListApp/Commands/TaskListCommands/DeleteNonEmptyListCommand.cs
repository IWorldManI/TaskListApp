using MediatR;
using TaskListApp.Database.Models.TaskListModel;

public class DeleteNonEmptyListCommand : IRequest<TaskList>
{
    public int SourceListId { get; set; }
    public int TargetListId { get; set; }
}
