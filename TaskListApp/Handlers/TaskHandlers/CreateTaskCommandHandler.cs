using MediatR;
using TaskListApp.Commands.TaskCommands;
using TaskListApp.Services.TaskService;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Handlers.TaskHandlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskItem>
    {
        private readonly ITaskService _taskService;

        public CreateTaskCommandHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<TaskItem> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            return await _taskService.CreateTaskAsync(request);
        }
    }
}
