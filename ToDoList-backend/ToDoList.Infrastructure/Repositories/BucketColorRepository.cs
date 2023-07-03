﻿using ToDoList.Api;
using ToDoList.Domain.Models;
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
        return _toDoListDbContext.BucketColors.ToList();
    }
}