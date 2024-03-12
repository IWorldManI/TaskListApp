using Microsoft.EntityFrameworkCore;
using TaskListApp.Commands.TaskCommands;
using TaskListApp.Database.DBConnector;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Queries.TaskQueries;

namespace TaskListApp.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthenticationService _authenticationService;

        public TaskService(ApplicationDbContext context, AuthenticationService authenticationService)
        {
            _context = context;
            _authenticationService = authenticationService;
        }

        public async Task<TaskItem> CreateTaskAsync(CreateTaskCommand command)
        {
            try
            {
                var task = new TaskItem
                {
                    Title = command.Title,
                    Description = command.Description,
                    CreatedAt = DateTime.UtcNow,
                    Status = TaskCurrentStatus.Pending,
                    TaskListId = command.TaskListId,
                };

                _context.TaskItems.Add(task);

                var statusHistory = new TaskStatusHistory
                {
                    Status = TaskCurrentStatus.Pending,
                    ChangedAt = DateTime.UtcNow
                };

                task.StatusHistory.Add(statusHistory);

                await _context.SaveChangesAsync();

                return task;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the entity changes.", ex);
            }
        }

        public async Task<TaskItem> DeleteTaskAsync(DeleteTaskCommand command)
        {
            var task = await _context.TaskItems.FindAsync(command.Id);

            if (task == null)
            {
                throw new Exception("Task not found");
            }

            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<TaskItem> GetTaskByIdAsync(GetTaskByIdQuery query)
        {
            var task = await _context.TaskItems
                .Include(t => t.StatusHistory)
                .Include(t => t.Comments)
                .FirstOrDefaultAsync(t => t.Id == query.Id);

            if (task == null)
            {
                throw new Exception("Task not found");
            }

            return task;
        }

        public async Task<TaskItem> UpdateTaskAsync(UpdateTaskCommand command)
        {
            try
            {
                var task = await _context.TaskItems
                    .Include(t => t.StatusHistory)
                    .Include(t => t.Comments)
                    .FirstOrDefaultAsync(t => t.Id == command.Id);

                if (task == null)
                {
                    throw new Exception("Task not found");
                }

                task.Status = command.Status;

                task.StatusHistory.Add(new TaskStatusHistory
                {
                    Status = command.Status,
                    ChangedAt = DateTime.UtcNow
                });

                await _context.SaveChangesAsync();

                return task;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the entity changes.", ex);
            }
        }
    }
}