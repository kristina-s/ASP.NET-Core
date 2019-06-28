using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.WebApp.Models.Enums;

namespace Todo.WebApp.Models
{
    public abstract class BaseTask
    {
        public static int LastGeneratedId { get; private set; }
        static BaseTask()
        {
            LastGeneratedId = 0;
        }
        public BaseTask()
        {
            Id = ++LastGeneratedId;
        }
        public int Id { get; set; }
        public string  Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
