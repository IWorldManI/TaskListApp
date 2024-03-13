using TaskListApp.Commands.TaskCommands;
using TaskListApp.Queries.TaskQueries;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Services.TaskService
{
    public interface ITaskService
    {
        Task<TaskItem> CreateTaskAsync(CreateTaskCommand command);
        Task<TaskItem> GetTaskByIdAsync(GetTaskByIdQuery query);
        Task<TaskItem> UpdateTaskAsync(UpdateTaskCommand command);
        Task<TaskItem> DeleteTaskAsync(DeleteTaskCommand command);
    }
}
