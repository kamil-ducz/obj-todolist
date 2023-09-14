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

    public IReadOnlyList<Bucket> GetAllBuckets()
    {
        var buckets = _toDoListDbContext.Buckets.ToList();
        return buckets;
    }

    public Bucket GetBucket(int bucketId)
    {
        var bucket = _toDoListDbContext.Buckets!.First(a => a.Id == bucketId);
        return bucket;
    }

    public void DeleteBucket(Bucket bucketToDelete)
    {
        _toDoListDbContext.Buckets!.Remove(bucketToDelete);
        _toDoListDbContext.SaveChanges();
    }

    public void InsertBucket(Bucket bucketToInsert)
    {
        _toDoListDbContext.Buckets!.Add(bucketToInsert);
        _toDoListDbContext.SaveChanges();
    }

    public void UpdateBucket(Bucket bucketToUpdate)
    {
        _toDoListDbContext.Buckets!.Update(bucketToUpdate);
        _toDoListDbContext.SaveChanges();
    }
}