﻿using System.Collections.Generic;

namespace ToDoList.Domain.Models;

public class Bucket
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int BucketCategoryId { get; set; }
    public BucketCategory? BucketCategory { get; set; }
    public int BucketColorId { get; set; }
    public BucketColor? BucketColor { get; set; }
    public int MaxAmountOfTasks { get; set; }
    public bool IsActive { get; set; }
    public List<BucketTask> BucketTask { get; set; } = new List<BucketTask>();
}
