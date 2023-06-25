using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Domain.Enums;

namespace ToDoList.Api.Bucket.Models;

public class BucketInsertDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Category Category { get; set; }
    public BucketColor BucketColor { get; set; }
    public int? MaxAmountOfTasks { get; set; }
    public bool IsActive { get; set; }
    public List<BucketTaskDto>? BucketTasks { get; set; }
}
