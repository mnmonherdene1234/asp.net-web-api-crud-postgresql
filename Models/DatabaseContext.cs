using Microsoft.EntityFrameworkCore;
namespace WebAPITest.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
        modelBuilder.Entity<Student>().HasMany<Course>(s => s.Courses).WithMany(c => c.Students);
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
}