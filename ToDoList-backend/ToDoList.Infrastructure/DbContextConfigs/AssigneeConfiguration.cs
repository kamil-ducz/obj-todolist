using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class AssigneeConfiguration : IEntityTypeConfiguration<Assignee>
{
    public void Configure(EntityTypeBuilder<Assignee> builder)
    {
        builder.HasData(
            new Assignee { Id = 1, Name = "John Doe" }
        );
    }
}
