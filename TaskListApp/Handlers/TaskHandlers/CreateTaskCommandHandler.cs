using MediatR;
using TaskListApp.Commands.TaskCommands;
using TaskListApp.Services.TaskService;
using TaskListApp.Services;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Handlers.TaskHandlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskItem>
    {
        private readonly ITaskService _taskService;
        private readonly AuthenticationService _authenticationService;

        public CreateTaskCommandHandler(ITaskService taskService, AuthenticationService authenticationService)
        {
            _taskService = taskService;
            _authenticationService = authenticationService;
        }

        public async Task<TaskItem> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _taskService.CreateTaskAsync(request);
        }
    }
}
