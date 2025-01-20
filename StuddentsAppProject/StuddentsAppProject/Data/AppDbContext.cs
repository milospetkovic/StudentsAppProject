namespace StuddentsAppProject.Data;

using Microsoft.EntityFrameworkCore;
using StuddentsAppProject.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    public DbSet<Exam> Exams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Unique constraint.
        modelBuilder.Entity<Student>()
            .HasIndex(s => new { s.FirstName, s.LastName, s.BirthDate, s.JMBG })
            .IsUnique();

        // Unique constraint.
        modelBuilder.Entity<Subject>()
            .HasIndex(s => new { s.Name })
            .IsUnique();
    }
}

