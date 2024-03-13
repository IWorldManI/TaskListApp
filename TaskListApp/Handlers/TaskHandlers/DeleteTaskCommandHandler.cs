using MediatR;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Services.TaskService;
using TaskListApp.Services.AuthentificationService;

namespace TaskListApp.Handlers.TaskHandlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, TaskItem>
    {
        private readonly ITaskService _taskService;
        private readonly AuthenticationService _authenticationService;

        public DeleteTaskCommandHandler(ITaskService taskService, AuthenticationService authenticationService)
        {
            _taskService = taskService;
            _authenticationService = authenticationService;
        }

        public async Task<TaskItem> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _taskService.DeleteTaskAsync(request);
        }
    }
}