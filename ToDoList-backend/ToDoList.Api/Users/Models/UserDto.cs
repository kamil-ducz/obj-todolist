namespace ToDoList.Api.Users.Models;

public record UserDto(
    int Id,
    string? FirstName,
    string? LastName,
    string Username,
    string Email,
    string Password
    );