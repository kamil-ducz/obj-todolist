using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Domain.Enums;

namespace ToDoList.Api.Bucket.Models;

public class BucketUpsertDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public BucketCategory? BucketCategory { get; set; }
    public int BucketColorId { get; set; }
    public BucketColor? BucketColor { get; set; }
    public int MaxAmountOfTasks { get; set; } = 1;
    public bool IsActive { get; set; }
    public List<BucketTaskDto> BucketTasks { get; set; } = new List<BucketTaskDto>();
}
