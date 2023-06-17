using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            modelBuilder.Entity<Domain.Models.Stats>()
                        .Property(s => s.Cancelled)
                        .HasPrecision(3, 0);

            modelBuilder.Entity<Domain.Models.Stats>()
                        .Property(s => s.Completed)
                        .HasPrecision(3, 0);

            modelBuilder.Entity<Domain.Models.Stats>()
                        .Property(s => s.InProgress)
                        .HasPrecision(3, 0);

            modelBuilder.Entity<Domain.Models.Stats>()
                        .Property(s => s.ToDo)
                        .HasPrecision(3, 0);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("ToDoListDatabase"), b => b.MigrationsAssembly("ToDoList.Infrastructure"));
        }

        public DbSet<Domain.Models.Assignee>? Assignees { get; set; }
        public DbSet<Domain.Models.Bucket>? Buckets { get; set; }
        public DbSet<Domain.Models.BucketTask>? BucketTasks { get; set; }
        public DbSet<Domain.Models.Stats>? Stats { get; set; }
    }
}
