using MediatR;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Services.TaskService;

namespace TaskListApp.Handlers.TaskHandlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, TaskItem>
    {
        private readonly ITaskService _taskService;

        public DeleteTaskCommandHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<TaskItem> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            return await _taskService.DeleteTaskAsync(request);
        }
    }
}