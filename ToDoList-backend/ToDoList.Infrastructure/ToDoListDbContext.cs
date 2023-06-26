using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDoList.Domain.Models;
using ToDoList.Infrastructure.DbContextConfigs;

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

        modelBuilder.ApplyConfiguration(new BucketTaskConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(configuration.GetConnectionString("ToDoListDatabase"), b => b.MigrationsAssembly("ToDoList.Infrastructure"));
    }

    public DbSet<Assignee> Assignees { get; set; }
    public DbSet<Bucket> Buckets { get; set; }
    public DbSet<BucketTask> BucketTasks { get; set; }
}
