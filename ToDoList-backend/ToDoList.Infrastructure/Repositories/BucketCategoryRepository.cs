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
        return _toDoListDbContext.BucketCategory.ToList();
    }

    public BucketCategory GetBucketCategoryByName(string bucketCategoryName)
    {
        return _toDoListDbContext.BucketCategory.First(x => x.Name == bucketCategoryName);
    }

    public BucketCategory GetBucketCategoryById(int bucketCategoryId)
    {
        return _toDoListDbContext.BucketCategory.First(x => x.Id == bucketCategoryId);
    }
}