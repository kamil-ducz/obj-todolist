using ToDoList.Api;
using ToDoList.Domain.Enums;
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

    public int GetBucketColorIdByName(string bucketColorName)
    {
        return _toDoListDbContext.BucketColor.First(bc => bc.Name == bucketColorName).Id;
    }

    public string GetBucketColorNameById(int bucketColorId)
    {
        return _toDoListDbContext.BucketColor.First(bc => bc.Id == bucketColorId).Name;
    }
}