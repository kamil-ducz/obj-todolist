﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDoList.Domain.Models;

namespace ToDoList.Api
{
    public class ToDoListDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ToDoListDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignee>().HasData(
                new Assignee { Id = 1, Name = "John Doe" }
                );

            modelBuilder.Entity<Bucket>().HasData(
                new Bucket { Id = 1, Name = "Work", IsActive = true },
                new Bucket { Id = 2, Name = "Home", IsActive = true },
                new Bucket { Id = 3, Name = "Hobby", IsActive = true })
                ;

            modelBuilder.Entity<BucketTask>().HasData(
                new BucketTask { Id = 1, BucketId = 1, Name = "Speak to manager", TaskState = Domain.Enums.Enums.TaskState.ToDo },
                new BucketTask { Id = 2, BucketId = 1, Name = "Organize desk", TaskState = Domain.Enums.Enums.TaskState.InProgress },
                new BucketTask { Id = 3, BucketId = 2, Name = "Water plants", TaskState = Domain.Enums.Enums.TaskState.Cancelled },
                new BucketTask { Id = 4, BucketId = 2, Name = "Clean bedroom", TaskState = Domain.Enums.Enums.TaskState.Done },
                new BucketTask { Id = 5, BucketId = 3, Name = "Organize diet", TaskState = Domain.Enums.Enums.TaskState.Done },
                new BucketTask { Id = 6, BucketId = 3, Name = "Update training plan", TaskState = Domain.Enums.Enums.TaskState.InProgress });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("ToDoListDatabase"), b => b.MigrationsAssembly("ToDoList.Infrastructure"));
        }

        public DbSet<Domain.Models.Assignee>? Assignees { get; set; }
        public DbSet<Domain.Models.Bucket>? Buckets { get; set; }
        public DbSet<Domain.Models.BucketTask>? BucketTasks { get; set; }
    }
}
