using MediatR;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Services.TaskListService;

namespace TaskListApp.Handlers.TaskListHandlers
{
    public class DeleteNonEmptyListAsyncCommandHandler : IRequestHandler<DeleteNonEmptyListCommand, TaskList>
    {
        private readonly ITaskListService _taskListService;

        public DeleteNonEmptyListAsyncCommandHandler(ITaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        public async Task<TaskList> Handle(DeleteNonEmptyListCommand request, CancellationToken cancellationToken)
        {
            return await _taskListService.DeleteNonEmptyListAsync(request);
        }
    }
}