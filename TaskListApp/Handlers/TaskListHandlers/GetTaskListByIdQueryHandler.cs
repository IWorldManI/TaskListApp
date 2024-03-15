using MediatR;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Queries.TaskListQueries;
using TaskListApp.Services.TaskListService;

namespace TaskListApp.Handlers.TaskListHandlers
{
    public class GetTaskListByIdQueryHandler : IRequestHandler<GetTaskListByIdQuery, TaskList>
    {
        private readonly ITaskListService _taskListService;
        public GetTaskListByIdQueryHandler(ITaskListService taskListService)
        {
            _taskListService = taskListService; 
        }
        public async Task<TaskList> Handle(GetTaskListByIdQuery request, CancellationToken cancellationToken)
        {
            return await _taskListService.GetTaskListByIdAsync(request);
        }
    }
}