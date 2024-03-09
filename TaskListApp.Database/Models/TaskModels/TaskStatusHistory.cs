using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListApp.Database.Models.TaskModels
{
    public class TaskStatusHistory
    {
        public int Id { get; set; }
        public TaskCurrentStatus Status { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}