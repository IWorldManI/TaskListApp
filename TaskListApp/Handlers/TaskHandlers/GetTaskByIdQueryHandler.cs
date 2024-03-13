using MediatR;
using TaskListApp.Queries.TaskQueries;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Services.TaskService;
using TaskListApp.Services.AuthentificationService;

namespace TaskListApp.Handlers.TaskHandlers
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskItem>
    {
        private readonly ITaskService _taskService;
        private readonly AuthenticationService _authenticationService;

        public GetTaskByIdQueryHandler(ITaskService taskService, AuthenticationService authenticationService)
        {
            _taskService = taskService;
            _authenticationService = authenticationService;
        }

        public async Task<TaskItem> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _taskService.GetTaskByIdAsync(request);
        }
    }
}
