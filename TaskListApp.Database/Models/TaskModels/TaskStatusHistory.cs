using System.Text.Json.Serialization;

namespace TaskListApp.Database.Models.TaskModels
{
    public class TaskStatusHistory
    {
        [JsonIgnore]
        public int Id { get; set; }
        public TaskCurrentStatus Status { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}