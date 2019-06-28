using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.WebApp.Models
{
    public class SubTask : Task
    {
        public Task ParentTask { get; set; }
    }
}
