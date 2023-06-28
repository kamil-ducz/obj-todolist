using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketConfiguration : IEntityTypeConfiguration<Buckets>
{
    public void Configure(EntityTypeBuilder<Buckets> builder)
    {
        builder.HasData(
            new Buckets { Id = 1, Name = "Work", IsActive = true, MaxAmountOfTasks = 15 },
            new Buckets { Id = 2, Name = "Home", IsActive = true, MaxAmountOfTasks = 15 },
            new Buckets { Id = 3, Name = "Hobby", IsActive = true, MaxAmountOfTasks = 15 }
        );
    }
}
