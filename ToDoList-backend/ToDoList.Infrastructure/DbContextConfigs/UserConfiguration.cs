using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User() { Id = 1, FirstName = "John", LastName = "Doe", Username = "JD", Email = "example@example.com", Password = BCrypt.Net.BCrypt.HashPassword("test") },
            new User() { Id = 2, FirstName = "Ian", LastName = "Orange", Username = "IO", Email = "ian.orange@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("test2") },
            new User() { Id = 3, FirstName = "Walter", LastName = "Silver", Username = "WS", Email = "silverman@superpeople.com", Password = BCrypt.Net.BCrypt.HashPassword("test3") }
            );
    }
}