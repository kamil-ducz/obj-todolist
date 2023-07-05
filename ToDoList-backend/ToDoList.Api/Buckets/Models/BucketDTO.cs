using System.Collections.Generic;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Domain.Models;

namespace ToDoList.Api.Buckets.Models;

public class BucketDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int BucketCategoryId { get; set; }
    public BucketCategory? BucketCategory { get; set; }
    public int BucketColorId { get; set; }
    public BucketColor? BucketColor { get; set; }
    public int MaxAmountOfTasks { get; set; } = 1;
    public bool IsActive { get; set; }
    public List<BucketTaskDto> BucketTask { get; set; } = new List<BucketTaskDto>();
}
