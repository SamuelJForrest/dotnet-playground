using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotnetPlayground.Models;

namespace DotnetPlayground.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DotnetPlayground.Models.Blog> Blog { get; set; } = default!;
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
