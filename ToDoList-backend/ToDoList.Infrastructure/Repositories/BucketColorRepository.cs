﻿using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Infrastructure.Repositories;

public class BucketColorRepository : IBucketColorRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public BucketColorRepository(ToDoListDbContext toDoListDbContext)
    {
        _toDoListDbContext = toDoListDbContext;
    }

    public IReadOnlyList<BucketColor> GetAllBucketColors()
    {
        return _toDoListDbContext.BucketColor.ToList();
    }

    public BucketColor GetBucketColorByName(string bucketColorName)
    {
        return _toDoListDbContext.BucketColor.First(bc => bc.Name == bucketColorName);
    }

    public BucketColor GetBucketColorById(int bucketColorId)
    {
        return _toDoListDbContext.BucketColor.First(bc => bc.Id == bucketColorId);
    }
}