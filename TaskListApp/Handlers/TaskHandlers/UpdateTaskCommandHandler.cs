using MediatR;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Services.TaskService;
using TaskListApp.Services;

namespace TaskListApp.Handlers.TaskHandlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskItem>
    {
        private readonly ITaskService _taskService;
        private readonly AuthenticationService _authenticationService;
        
        public UpdateTaskCommandHandler(ITaskService taskService, AuthenticationService authenticationService)
        {
            _taskService = taskService; 
            _authenticationService = authenticationService; 
        }

        public async Task<TaskItem> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _taskService.UpdateTaskAsync(request);
        }
    }
}