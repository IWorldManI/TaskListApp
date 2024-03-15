using MediatR;
using TaskListApp.Commands.TaskListCommands;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Services.TaskListService;

namespace TaskListApp.Handlers.TaskListHandlers
{
    public class DeleteTaskListCommandHandler : IRequestHandler<DeleteTaskListCommand, TaskList>
    {
        private readonly ITaskListService _taskListService;

        public DeleteTaskListCommandHandler(ITaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        public async Task<TaskList> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
        {
            return await _taskListService.DeleteTaskListAsync(request);
        }
    }
    
}
