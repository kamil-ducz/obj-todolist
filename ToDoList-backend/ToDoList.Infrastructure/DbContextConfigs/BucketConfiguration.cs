using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketConfiguration : IEntityTypeConfiguration<Bucket>
{
    public void Configure(EntityTypeBuilder<Bucket> builder)
    {
        builder.HasData(
            new Bucket { Id = 1, Name = "Work", IsActive = true, MaxAmountOfTasks = 15 },
            new Bucket { Id = 2, Name = "Home", IsActive = true, MaxAmountOfTasks = 15 },
            new Bucket { Id = 3, Name = "Hobby", IsActive = true, MaxAmountOfTasks = 15 }
        );
    }
}
