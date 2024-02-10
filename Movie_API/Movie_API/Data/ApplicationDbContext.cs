using Microsoft.EntityFrameworkCore;
using Movie_API.Models;

namespace Movie_API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Movies> Moviess { get; set; }
    }
}
