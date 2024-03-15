using MediatR;
using TaskListApp.Queries.TaskQueries;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Services.TaskService;

namespace TaskListApp.Handlers.TaskHandlers
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskItem>
    {
        private readonly ITaskService _taskService;

        public GetTaskByIdQueryHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<TaskItem> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _taskService.GetTaskByIdAsync(request);
        }
    }
}
