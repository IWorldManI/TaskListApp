using MediatR;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Services.TaskListService;

namespace TaskListApp.Handlers.TaskListHandlers
{
    public class MoveTasksToAnotherListCommandHandler : IRequestHandler<MoveTasksToAnotherListCommand, TaskList>
    {
        private readonly ITaskListService _taskListService;

        public MoveTasksToAnotherListCommandHandler(ITaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        public async Task<TaskList> Handle(MoveTasksToAnotherListCommand request, CancellationToken cancellationToken)
        {
            return await _taskListService.MoveTasksToAnotherListAsync(request);
        }
    }
}
