using ToDoList.Api;
using ToDoList.Domain.Enums;
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

    public int GetBucketCategoryIdByName(string bucketCategoryName)
    {
        return _toDoListDbContext.BucketCategory.First(bcat => bcat.Name == bucketCategoryName).Id;
    }

    public string GetBucketCategoryNameById(int bucketCategoryId)
    {
        return _toDoListDbContext.BucketCategory.First(bcat => bcat.Id == bucketCategoryId).Name;
    }
}