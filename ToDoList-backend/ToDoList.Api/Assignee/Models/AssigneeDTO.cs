using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Asignee.Models;

public class AssigneeDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual List<BucketTaskDTO>? BucketTasks { get; set; }
}
