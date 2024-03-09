using MediatR;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Queries.TaskQueries
{
    public class GetTaskByIdQuery : IRequest<TaskItem>
    {
        public int Id { get; set; }
    }
}