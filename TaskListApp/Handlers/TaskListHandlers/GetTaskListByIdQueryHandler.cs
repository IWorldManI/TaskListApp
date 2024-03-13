using MediatR;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Queries.TaskListQueries;
using TaskListApp.Services.TaskListService;
using TaskListApp.Services.AuthentificationService;

namespace TaskListApp.Handlers.TaskListHandlers
{
    public class GetTaskListByIdQueryHandler : IRequestHandler<GetTaskListByIdQuery, TaskList>
    {
        private readonly ITaskListService _taskListService;
        private readonly AuthenticationService _authenticationService;
        public GetTaskListByIdQueryHandler(ITaskListService taskListService, AuthenticationService authenticationService)
        {
            _taskListService = taskListService; 
            _authenticationService = authenticationService;
        }
        public async Task<TaskList> Handle(GetTaskListByIdQuery request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _taskListService.GetTaskListByIdAsync(request);
        }
    }
}