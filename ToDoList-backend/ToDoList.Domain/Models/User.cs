﻿namespace ToDoList.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; set; } = string.Empty;
    public required string Email { get; set; }
    public string Password { get; set; } = string.Empty;
}
