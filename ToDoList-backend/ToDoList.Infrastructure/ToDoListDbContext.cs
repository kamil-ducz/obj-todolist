using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Models;
using ToDoList.Infrastructure.DbContextConfigs;

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
        modelBuilder.ApplyConfiguration(new AssigneeConfiguration());
        modelBuilder.ApplyConfiguration(new BucketConfiguration());
        modelBuilder.ApplyConfiguration(new BucketCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new BucketColorConfiguration());
        modelBuilder.ApplyConfiguration(new BucketTaskConfiguration());
        modelBuilder.ApplyConfiguration(new BucketTaskStateConfiguration());
        modelBuilder.ApplyConfiguration(new BucketTaskPriorityConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(configuration.GetConnectionString("ToDoListDatabase"), b => b.MigrationsAssembly("ToDoList.Infrastructure"));
    }

    public DbSet<Assignee> Assignee { get; set; }
    public DbSet<Bucket> Bucket { get; set; }
    public DbSet<BucketCategory> BucketCategory { get; set; }
    public DbSet<BucketColor> BucketColor { get; set; }
    public DbSet<BucketTask> BucketTask { get; set; }
    public DbSet<BucketTaskState> BucketTaskState { get; set; }
    public DbSet<BucketTaskPriority> BucketTaskPriority { get; set; }
}
