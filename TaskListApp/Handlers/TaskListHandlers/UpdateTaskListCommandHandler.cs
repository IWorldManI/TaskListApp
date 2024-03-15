using MediatR;
using TaskListApp.Commands.TaskListCommands;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Services.TaskListService;

namespace TaskListApp.Handlers.TaskListHandlers
{
    public class UpdateTaskListCommandHandler : IRequestHandler<UpdateTaskListCommand, TaskList>
    {
        private readonly ITaskListService _taskListService;
        public UpdateTaskListCommandHandler(ITaskListService taskListService) 
        {
            _taskListService = taskListService;
        }

        public async Task<TaskList> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
        {
            return await _taskListService.UpdateTaskListAsync(request);        
        }
    }
}
