using Microsoft.EntityFrameworkCore;
namespace A3API.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Picture> Pictures { get; set; }

    }

}
