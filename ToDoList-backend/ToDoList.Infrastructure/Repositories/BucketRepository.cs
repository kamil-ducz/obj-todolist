using ToDoList.Api;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Infrastructure.Repositories;

public class BucketRepository : IBucketRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public BucketRepository(ToDoListDbContext toDoListDbContext)
    {
        _toDoListDbContext = toDoListDbContext;
    }

    public IReadOnlyList<Buckets> GetAllBuckets()
    {
        return _toDoListDbContext.Buckets!.ToList();
    }

    public Buckets GetBucket(int bucketId)
    {
        return _toDoListDbContext.Buckets!.First(a => a.Id == bucketId);
    }

    public void DeleteBucket(Buckets bucketToDelete)
    {
        _toDoListDbContext.Buckets!.Remove(bucketToDelete);
        _toDoListDbContext.SaveChanges();
    }

    public void InsertBucket(Buckets bucketToInsert)
    {
        _toDoListDbContext.Buckets!.Add(bucketToInsert);
        _toDoListDbContext.SaveChanges();
    }

    public void UpdateBucket(Buckets bucketToUpdate)
    {
        _toDoListDbContext.Buckets!.Update(bucketToUpdate);
        _toDoListDbContext.SaveChanges();
    }
}