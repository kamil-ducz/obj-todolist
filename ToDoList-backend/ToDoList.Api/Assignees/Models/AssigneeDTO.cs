namespace ToDoList.Api.Assignees.Models;

public record AssigneeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
