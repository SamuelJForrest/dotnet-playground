using System.Collections.Generic;
using DotnetPlayground.Models;

namespace DotnetPlayground.ViewModels
{
    public class TaskListViewModel
    {
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public TaskItem NewTask { get; set; } = new TaskItem();
    }
}
