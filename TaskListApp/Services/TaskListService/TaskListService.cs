using Microsoft.EntityFrameworkCore;
using TaskListApp.Commands.TaskListCommands;
using TaskListApp.Database.DBConnector;
using TaskListApp.Database.Models.TaskListModel;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Queries.TaskListQueries;

namespace TaskListApp.Services.TaskListService
{
    public class TaskListService : ITaskListService
    {
        private readonly ApplicationDbContext _context;

        public TaskListService(ApplicationDbContext context)
        {
            _context = context;
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
            var taskList = await _context.TaskLists
                .Include(list => list.Tasks)
                .FirstOrDefaultAsync(list => list.Id == command.Id);

            if (taskList == null)
            {
                throw new Exception("Task list not found");
            }

            if (taskList.Tasks.Any())
            {
                throw new Exception("Cannot delete a non-empty task list. Please use the method to delete a non-empty list and specify where tasks will be moved.");
            }

            _context.TaskLists.Remove(taskList);
            await _context.SaveChangesAsync();

            return taskList;
        }

        public async Task<TaskList> GetTaskListByIdAsync(GetTaskListByIdQuery query)
        {
            var taskList = await _context.TaskLists
                .Include(t => t.Tasks)
                .FirstOrDefaultAsync(t => t.Id == query.Id);

            if (taskList == null)
            {
                throw new Exception("Task list not found");
            }

            return taskList;
        }

        public async Task<TaskList> UpdateTaskListAsync(UpdateTaskListCommand command)
        {
            var taskList = await _context.TaskLists.FindAsync(command.Id);

            if (taskList == null)
            {
                throw new Exception("Task list not found");
            }

            taskList.Title = command.Title;
            taskList.Description = command.Description;

            await _context.SaveChangesAsync();

            return taskList;
        }

        public async Task<TaskList> MoveTasksToAnotherList(MoveTasksToAnotherListCommand command)
        {
            var sourceList = await _context.TaskLists
                .Include(list => list.Tasks)
                .FirstOrDefaultAsync(list => list.Id == command.SourceListId);

            if (sourceList == null)
            {
                throw new Exception("Source list not found");
            }

            if (!sourceList.Tasks.Any())
            {
                throw new Exception("Source list is empty.");
            }

            if (sourceList.Tasks.Any())
            {
                var targetList = await _context.TaskLists
                    .Include(list => list.Tasks)
                    .FirstOrDefaultAsync(list => list.Id == command.TargetListId);

                if (targetList == null)
                {
                    throw new Exception("Target list not found");
                }

                foreach (var task in sourceList.Tasks)
                {
                    task.TaskListId = command.TargetListId;
                }

                await _context.SaveChangesAsync();

                return targetList;
            }

            return null;
        }
    }
}
