using MediatR;
using TaskListApp.Database.Models.TaskListModel;

namespace TaskListApp.Queries.TaskListQueries
{
    public class GetTaskListByIdQuery : IRequest<TaskList>
    {
        public int Id { get; set; }
    }
}
