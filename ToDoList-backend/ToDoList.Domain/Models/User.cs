﻿using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; set; } = string.Empty;
    [EmailAddress]
    public string? Email { get; set; }
    public string Password { get; set; } = string.Empty;
}
