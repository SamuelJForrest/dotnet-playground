using System.ComponentModel.DataAnnotations;

namespace DotnetPlayground.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [StringLength(60)]
        public string? Author { get; set; }

        [StringLength((500), MinimumLength = 1)]
        public string? Content { get; set; }
    }
}
