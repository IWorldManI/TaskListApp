using Microsoft.EntityFrameworkCore;
using TaskListApp.Commands.TaskListCommands;
using TaskListApp.Database.DBConnector;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Queries.TaskListQueries;

namespace TaskListApp.Services.TaskListService
{
    public class TaskListService : ITaskListService
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthenticationService _authenticationService;

        public TaskListService(ApplicationDbContext context, AuthenticationService authenticationService)
        {
            _context = context;
            _authenticationService = authenticationService;
        }

        public async Task<TaskList> CreateTaskListAsync(CreateTaskListCommand command)
        {
            var taskList = new TaskList
            {
                Title = command.Title,
                Description = command.Description,
            };

            _context.TaskLists.Add(taskList);
            await _context.SaveChangesAsync();

            return taskList;
        }


        public async Task<TaskList> DeleteTaskListAsync(DeleteTaskListCommand command)
        {
            var taskList = await _context.TaskLists.FindAsync(command.Id);

            if (taskList == null)
            {
                throw new Exception("Список задач не найден");
            }

            _context.TaskLists.Remove(taskList);
            await _context.SaveChangesAsync();

            return taskList;
        }

        public async Task<TaskList> GetTaskListByIdAsync(GetTaskListByIdQuery query)
        {
            var taskList = await _context.TaskLists.Include(t => t.Tasks).FirstOrDefaultAsync(t => t.Id == query.Id);

            if (taskList == null)
            {
                throw new Exception("Список задач не найден"); 
            }

            return taskList;
        }

        public async Task<TaskList> UpdateTaskListAsync(UpdateTaskListCommand command)
        {
            var taskList = await _context.TaskLists.FindAsync(command.Id);

            if (taskList == null)
            {
                throw new Exception("Список задач не найден");
            }

            taskList.Title = command.Title;
            taskList.Description = command.Description;

            await _context.SaveChangesAsync();

            return taskList;
        }
    }
}
