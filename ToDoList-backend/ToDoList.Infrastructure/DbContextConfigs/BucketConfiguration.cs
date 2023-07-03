using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketConfiguration : IEntityTypeConfiguration<Bucket>
{
    public void Configure(EntityTypeBuilder<Bucket> builder)
    {
        builder.HasData(
            new Bucket { Id = 1, Name = "Objectivity", IsActive = true, MaxAmountOfTasks = 15, BucketCategoryId = (int)Domain.Enums.BucketCategory.Home, BucketColorId = (int)Domain.Enums.BucketColor.Brown },
            new Bucket { Id = 2, Name = "Kitchen", IsActive = true, MaxAmountOfTasks = 15, BucketCategoryId = (int)Domain.Enums.BucketCategory.Home, BucketColorId = (int)Domain.Enums.BucketColor.Red },
            new Bucket { Id = 3, Name = "Gym", IsActive = true, MaxAmountOfTasks = 15, BucketCategoryId = (int)Domain.Enums.BucketCategory.Home, BucketColorId = (int)Domain.Enums.BucketColor.Blue }
        );
    }
}
