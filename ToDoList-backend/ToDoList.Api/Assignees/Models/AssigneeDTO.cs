using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Api.Assignees.Models;

public record AssigneeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<BucketTask>? BucketTask { get; set; }
}
