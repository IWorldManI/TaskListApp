using MediatR;
using TaskListApp.Commands.TaskListCommands;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Services.TaskListService;
using TaskListApp.Services;

namespace TaskListApp.Handlers.TaskListHandlers
{
    public class UpdateTaskListCommandHandler : IRequestHandler<UpdateTaskListCommand, TaskList>
    {
        private readonly ITaskListService _taskListService;
        private readonly AuthenticationService _authenticationService;
        public UpdateTaskListCommandHandler(ITaskListService taskListService, AuthenticationService authenticationService) 
        {
            _taskListService = taskListService;
            _authenticationService = authenticationService;
        }

        public async Task<TaskList> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _taskListService.UpdateTaskListAsync(request);        
        }
    }
}
