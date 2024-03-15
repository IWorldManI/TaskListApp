using MediatR;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Services.TaskService;

namespace TaskListApp.Handlers.TaskHandlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskItem>
    {
        private readonly ITaskService _taskService;
        
        public UpdateTaskCommandHandler(ITaskService taskService)
        {
            _taskService = taskService;  
        }

        public async Task<TaskItem> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            return await _taskService.UpdateTaskAsync(request);
        }
    }
}