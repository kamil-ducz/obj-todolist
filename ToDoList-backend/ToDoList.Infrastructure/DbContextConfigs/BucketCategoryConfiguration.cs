using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketCategoryConfiguration : IEntityTypeConfiguration<BucketCategory>
{
    public void Configure(EntityTypeBuilder<BucketCategory> builder)
    {
        builder.HasData(
            new BucketCategory() { Id = (int)Domain.Enums.BucketCategory.Work, Name = "Work" },
            new BucketCategory() { Id = (int)Domain.Enums.BucketCategory.Home, Name = "Home" },
            new BucketCategory() { Id = (int)Domain.Enums.BucketCategory.Hobby, Name = "Hobby" }
        );
    }
}
