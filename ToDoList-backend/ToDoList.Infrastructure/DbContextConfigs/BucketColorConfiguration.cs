using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketColorConfiguration : IEntityTypeConfiguration<BucketColor>
{
    public void Configure(EntityTypeBuilder<BucketColor> builder)
    {
        builder.HasData(
            new BucketColor() { Id = (int)Domain.Enums.BucketColor.Brown, Name = "Brown" },
            new BucketColor() { Id = (int)Domain.Enums.BucketColor.Red, Name = "Red" },
            new BucketColor() { Id = (int)Domain.Enums.BucketColor.Yellow, Name = "Yellow" },
            new BucketColor() { Id = (int)Domain.Enums.BucketColor.Blue, Name = "Blue" },
            new BucketColor() { Id = (int)Domain.Enums.BucketColor.White, Name = "White" },
            new BucketColor() { Id = (int)Domain.Enums.BucketColor.Green, Name = "Green" }
        );
    }
}