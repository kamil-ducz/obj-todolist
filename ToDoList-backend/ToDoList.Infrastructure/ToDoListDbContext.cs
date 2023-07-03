using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDoList.Domain.Models;

// Declared db sets will never be null
#pragma warning disable CS8618

namespace ToDoList.Api;

public class ToDoListDbContext : DbContext
{
    private readonly IConfiguration configuration;

    public ToDoListDbContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoListDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(configuration.GetConnectionString("ToDoListDatabase"), b => b.MigrationsAssembly("ToDoList.Infrastructure"));
    }

    public DbSet<Assignee> Assignees { get; set; }
    public DbSet<Bucket> Buckets { get; set; }
    public DbSet<BucketCategory> BucketCategories { get; set; }
    public DbSet<BucketColor> BucketColors { get; set; }
    public DbSet<BucketTask> BucketTasks { get; set; }
    public DbSet<BucketTaskState> BucketTaskStates { get; set; }
    public DbSet<BucketTaskPriority> BucketTaskPriorities { get; set; }
}
