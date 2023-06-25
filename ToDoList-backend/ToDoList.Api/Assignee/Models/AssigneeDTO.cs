using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Asignee.Models;

public record AssigneeDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<BucketTaskDto>? BucketTasks { get; set; }
}
