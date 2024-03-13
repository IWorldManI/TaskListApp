using System.Text.Json.Serialization;
using TaskListApp.Database.Models.TaskListModel;

namespace TaskListApp.Database.Models.TaskModels
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public TaskCurrentStatus Status { get; set; }
        public int TaskListId { get; set; }
        public List<TaskStatusHistory> StatusHistory { get; set; } = new List<TaskStatusHistory>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}