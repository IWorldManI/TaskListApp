using System.Text.Json.Serialization;

namespace TaskListApp.Database.Models.TaskModels
{
    public class Comment
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int TaskItemId { get; set; }
    }
}