using MediatR;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Services.AuthentificationService;
using TaskListApp.Services.TaskListService;

namespace TaskListApp.Handlers.TaskListHandlers
{
    public class MoveTasksToAnotherListCommandHandler : IRequestHandler<MoveTasksToAnotherListCommand, TaskList>
    {
        private readonly ITaskListService _taskListService;
        private readonly AuthenticationService _authenticationService;

        public MoveTasksToAnotherListCommandHandler(ITaskListService taskListService, AuthenticationService authenticationService)
        {
            _taskListService = taskListService;
            _authenticationService = authenticationService;
        }

        public async Task<TaskList> Handle(MoveTasksToAnotherListCommand request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _taskListService.MoveTasksToAnotherList(request);
        }
    }
}
