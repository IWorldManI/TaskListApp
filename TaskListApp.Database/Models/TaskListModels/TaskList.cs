using System.Text.Json.Serialization;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Database.Models.TaskListModel
{
    public class TaskList
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}