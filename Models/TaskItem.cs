using System.ComponentModel.DataAnnotations;

namespace DotnetPlayground.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsComplete { get; set; }
    }
}
