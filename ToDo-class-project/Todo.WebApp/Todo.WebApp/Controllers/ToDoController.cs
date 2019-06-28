using System;
using System.Collections.Generic;
using System.Linq;
using Todo.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Todo.WebApp.Models.Enums;

namespace Todo.WebApp.Controllers
{
    public class ToDoController : Controller
    {
        public IActionResult Index()
        {
            var tasks = new List<Task>
            {
                new Task
                {
                     Description = "Task 1 description",
                     Priority = Priority.important,
                     Title = "Write Homework!",
                     Status = Status.InProgress,
                     TaskType = TaskType.Personal,
                     SubTasks = new List<SubTask>
                     {
                         new SubTask
                         {
                             Title = "SubTask 01",
                             Description = "SubTask 1 of Task 1",
                             Status = Status.InProgress
                         },
                         new SubTask
                         {
                             Title = "SubTask 02",
                             Description = "SubTask 2 of Task 1",
                             Status = Status.NotDone
                         }
                     }

                },
                new Task
                {
                     Description = "Task 2 description",
                     Priority = Priority.important,
                     Title = "Walk the dog!",
                     Status = Status.Done,
                     TaskType = TaskType.Personal,
                     SubTasks = new List<SubTask>
                     {
                         new SubTask
                         {
                             Title = "SubTask 01",
                             Description = "SubTask 1 of Task 1",
                             Status = Status.Done
                         },
                         new SubTask
                         {
                             Title = "SubTask 02",
                             Description = "SubTask 2 of Task 1",
                             Status = Status.Done
                         }
                     }

                },
                new Task
                {
                     Description = "Task 1 description",
                     Priority = Priority.important,
                     Title = "Write Homework!",
                     Status = Status.NotDone,
                     TaskType = TaskType.Personal,
                     SubTasks = new List<SubTask>
                     {
                         new SubTask
                         {
                             Title = "SubTask 01",
                             Description = "SubTask 1 of Task 1",
                             Status = Status.InProgress
                         },
                         new SubTask
                         {
                             Title = "SubTask 02",
                             Description = "SubTask 2 of Task 1",
                             Status = Status.NotDone
                         }
                     }

                },


            };
            foreach (var task in tasks)
            {
                foreach (var subTask in task.SubTasks)
                {
                    subTask.ParentTask = task;
                }

            }
            var todoTasks = tasks
                    .Where(x => x.Status == Status.NotDone);

            return View(todoTasks);
        }
    }
}