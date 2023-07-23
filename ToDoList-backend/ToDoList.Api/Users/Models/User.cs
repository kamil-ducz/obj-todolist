using System.Text.Json.Serialization;

namespace ToDoList.Api.Users.Models;

public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; set; } = string.Empty;
    //[EmailAddress]
    //public string? Email { get; set; }
    [JsonIgnore]
    public string? Password { get; set; }
}
