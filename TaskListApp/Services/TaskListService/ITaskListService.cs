using TaskListApp.Commands.TaskListCommands;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Queries.TaskListQueries;

namespace TaskListApp.Services.TaskListService
{
    public interface ITaskListService
    {
        Task<TaskList> CreateTaskListAsync(CreateTaskListCommand command);
        Task<TaskList> GetTaskListByIdAsync(GetTaskListByIdQuery query);
        Task<TaskList> UpdateTaskListAsync(UpdateTaskListCommand command);
        Task<TaskList> DeleteTaskListAsync(DeleteTaskListCommand command);
        Task<TaskList> MoveTasksToAnotherList(MoveTasksToAnotherListCommand command);
    }
}
