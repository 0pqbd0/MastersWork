using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student?> Students { get; set; }
    public DbSet<Supervisor?> Supervisors { get; set; }
    public DbSet<Work?> Works { get; set; }
    public DbSet<Consultant?> Consultants { get; set; }
    public DbSet<Category?> Categories { get; set; }
    public DbSet<Department?> Departments { get; set; }
    public DbSet<User?> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Work>()
            .Property(w => w.Status)
            .HasDefaultValue(WorkStatus.NeedsReview);
        
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Student" },
            new Role { Id = 2, Name = "Reviewer" },
            new Role { Id = 3, Name = "DepartmentStaff" }
        );
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}