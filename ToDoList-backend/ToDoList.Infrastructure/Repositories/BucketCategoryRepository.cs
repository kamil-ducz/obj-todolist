using ToDoList.Api;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Infrastructure.Repositories;

public class BucketCategoryRepository : IBucketCategoryRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public BucketCategoryRepository(ToDoListDbContext toDoListDbContext)
    {
        _toDoListDbContext = toDoListDbContext;
    }

    public IReadOnlyList<BucketCategory> GetAllBucketCategories()
    {
        return _toDoListDbContext.BucketCategories.ToList();
    }
}