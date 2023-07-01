﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDoList.Domain.Models;
using ToDoList.Infrastructure.DbContextConfigs;

// Declared db sets will never be null
#pragma warning disable CS8618

namespace ToDoList.Infrastructure;

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
    public DbSet<BucketTask> BucketTasks { get; set; }
    public DbSet<BucketCategory> BucketCategory { get; set; }
    public DbSet<BucketColor> BucketColor { get; set; }
    public DbSet<TaskPriority> TaskPriorities { get; set; }
    public DbSet<TaskState> TaskStates { get; set; }
}
