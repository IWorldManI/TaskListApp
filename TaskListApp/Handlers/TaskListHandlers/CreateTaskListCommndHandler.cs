using MediatR;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Commands.TaskListCommands;
using TaskListApp.Services.TaskListService;
using TaskListApp.Services.AuthentificationService;

namespace TaskListApp.Handlers.TaskListHandlers
{
    public class CreateTaskListCommndHandler : IRequestHandler<CreateTaskListCommand, TaskList>
    {
        private readonly ITaskListService _taskListService;
        private readonly AuthenticationService _authenticationService;

        public CreateTaskListCommndHandler(ITaskListService taskListService, AuthenticationService authenticationService)
        {
            _taskListService = taskListService;
            _authenticationService = authenticationService;
        }

        public async Task<TaskList> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _taskListService.CreateTaskListAsync(request);
        }
    }
}
