using MediatR;
using TaskListApp.Commands.TaskListCommands;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Services;
using TaskListApp.Services.TaskListService;

namespace TaskListApp.Handlers.TaskListHandlers
{
    public class DeleteTaskListCommandHandler : IRequestHandler<DeleteTaskListCommand, TaskList>
    {
        private readonly ITaskListService _taskListService;
        private readonly AuthenticationService _authenticationService;

        public DeleteTaskListCommandHandler(ITaskListService taskListService, AuthenticationService authenticationService)
        {
            _taskListService = taskListService;
            _authenticationService = authenticationService;
        }

        public async Task<TaskList> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _taskListService.DeleteTaskListAsync(request);
        }
    }
    
}
