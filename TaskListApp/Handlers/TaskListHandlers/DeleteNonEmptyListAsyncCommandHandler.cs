using MediatR;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Services.AuthentificationService;
using TaskListApp.Services.TaskListService;

namespace TaskListApp.Handlers.TaskListHandlers
{
    public class DeleteNonEmptyListAsyncCommandHandler : IRequestHandler<DeleteNonEmptyListCommand, TaskList>
    {
        private readonly ITaskListService _taskListService;
        private readonly AuthenticationService _authenticationService;

        public DeleteNonEmptyListAsyncCommandHandler(ITaskListService taskListService, AuthenticationService authenticationService)
        {
            _taskListService = taskListService;
            _authenticationService = authenticationService;
        }

        public async Task<TaskList> Handle(DeleteNonEmptyListCommand request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _taskListService.DeleteNonEmptyListAsync(request);
        }
    }
}