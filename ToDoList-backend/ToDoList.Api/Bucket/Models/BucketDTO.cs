using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;
using static ToDoList.Domain.Enums.Enums;

namespace ToDoList.Api.Bucket.Models;

public class BucketDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Category Category { get; set; }
    public BucketColor BucketColor { get; set; }
    public int? MaxAmountOfTasks { get; set; }
    public bool IsActive { get; set; }
    public virtual List<BucketTaskDTO>? BucketTasks { get; set; }
}
