using Microsoft.EntityFrameworkCore;

namespace MVC_CRUD_App.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
