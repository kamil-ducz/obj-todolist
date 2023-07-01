using System.Collections.Generic;
using ToDoList.Api.BucketTasks.Models;

namespace ToDoList.Api.Assignees.Models;

public class AssigneeUpsertDto
{
    public string Name { get; set; } = string.Empty;
    public List<BucketTaskDto> BucketTasks { get; set; } = new List<BucketTaskDto>();
}
