using System.Collections.Generic;
using ToDoList.Api.BucketTasks.Models;

namespace ToDoList.Api.Assignees.Models;

public class AssigneeUpsertDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<BucketTaskDto> BucketTask { get; set; } = new List<BucketTaskDto>();
}
