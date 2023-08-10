﻿using System.ComponentModel.DataAnnotations;

namespace ToDoList.Api.Users.Models;

public class AuthenticateRequest
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }

    public AuthenticateRequest(string? username, string? password)
    {
        Username = username;
        Password = password;
    }
}
