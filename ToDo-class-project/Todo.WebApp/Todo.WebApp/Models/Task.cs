using System;
using System.Collections.Generic;
using System.Linq;
using Todo.WebApp.Models.Enums;

namespace Todo.WebApp.Models
{
    public class Task : BaseTask
    {
        public Priority Priority { get; set; }
        public TaskType TaskType { get; set; }

        public IEnumerable<SubTask> SubTasks { get; set; } 
    }
}
