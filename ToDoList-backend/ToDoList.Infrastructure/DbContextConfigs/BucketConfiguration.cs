using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketConfiguration : IEntityTypeConfiguration<Bucket>
{
    public void Configure(EntityTypeBuilder<Bucket> builder)
    {
        builder.HasData(
            new Bucket { Id = 1, Name = "Objectivity", BucketCategoryId = (int)Domain.Enums.BucketCategory.Home, BucketColorId = (int)Domain.Enums.BucketColor.Brown, MaxAmountOfTasks = 15, IsActive = true },
            new Bucket { Id = 2, Name = "Kitchen", BucketCategoryId = (int)Domain.Enums.BucketCategory.Home, BucketColorId = (int)Domain.Enums.BucketColor.Red, MaxAmountOfTasks = 15, IsActive = true },
            new Bucket { Id = 3, Name = "Gym", BucketCategoryId = (int)Domain.Enums.BucketCategory.Home, BucketColorId = (int)Domain.Enums.BucketColor.Blue, MaxAmountOfTasks = 15, IsActive = true }
        );
    }
}
