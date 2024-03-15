using MediatR;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Commands.TaskListCommands;
using TaskListApp.Services.TaskListService;

namespace TaskListApp.Handlers.TaskListHandlers
{
    public class CreateTaskListCommndHandler : IRequestHandler<CreateTaskListCommand, TaskList>
    {
        private readonly ITaskListService _taskListService;

        public CreateTaskListCommndHandler(ITaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        public async Task<TaskList> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
        {
            return await _taskListService.CreateTaskListAsync(request);
        }
    }
}
