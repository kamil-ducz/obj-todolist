using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Asignee.Models;

public class AssigneeInsertDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual List<BucketTaskDto>? BucketTasks { get; set; }
}
