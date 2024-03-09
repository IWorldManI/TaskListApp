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
                    Comments = command.Comments,
                };

                _context.TaskItems.Add(task);
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
                throw new Exception("Задача не найдена");
            }

            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<TaskItem> GetTaskByIdAsync(GetTaskByIdQuery query)
        {
            var task = await _context.TaskItems
                .Include(t => t.Comments) // Загружаем комментарии к задаче
                .FirstOrDefaultAsync(t => t.Id == query.Id);

            if (task == null)
            {
                throw new Exception("Задача не найдена");
            }

            return task;
        }

        public async Task<TaskItem> UpdateTaskAsync(UpdateTaskCommand command)
        {
            var task = await _context.TaskItems.FindAsync(command.Id);

            if (task == null)
            {
                throw new Exception("Задача не найдена");
            }

            task.Title = command.Title;
            task.Description = command.Description;
            task.Status = command.Status;

            await _context.SaveChangesAsync();

            return task;
        }
    }
}