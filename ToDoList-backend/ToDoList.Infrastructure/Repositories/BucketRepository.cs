using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

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
        return _toDoListDbContext.Buckets!.ToList();
    }

    public Bucket GetBucket(int bucketId)
    {
        return _toDoListDbContext.Buckets!.First(a => a.Id == bucketId);
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