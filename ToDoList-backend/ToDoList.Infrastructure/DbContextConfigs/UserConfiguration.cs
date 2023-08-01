using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User() { Id = 1, FirstName = "John", LastName = "Doe", Username = "JD", Password = "test" },
            new User() { Id = 2, FirstName = "Ian", LastName = "Orange", Username = "IO", Password = "test2" },
            new User() { Id = 3, FirstName = "Walter", LastName = "Silver", Username = "WS", Password = "test3" }
            );
    }
}