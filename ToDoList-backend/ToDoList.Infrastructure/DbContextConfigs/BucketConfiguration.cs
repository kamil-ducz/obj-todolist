using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketConfiguration : IEntityTypeConfiguration<Buckets>
{
    public void Configure(EntityTypeBuilder<Buckets> builder)
    {
        builder.HasData(
            new Buckets { Id = 1, Name = "Objectivity", IsActive = true, MaxAmountOfTasks = 15, BucketCategoryId = 1, BucketColorId = 1 },
            new Buckets { Id = 2, Name = "Kitchen", IsActive = true, MaxAmountOfTasks = 15, BucketCategoryId = 2, BucketColorId = 2 },
            new Buckets { Id = 3, Name = "Gym", IsActive = true, MaxAmountOfTasks = 15, BucketCategoryId = 3, BucketColorId = 3 }
        );
    }
}
