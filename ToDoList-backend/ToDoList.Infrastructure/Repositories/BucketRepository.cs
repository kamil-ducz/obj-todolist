using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Repositories;

public class BucketRepository : IBucketRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public BucketRepository(ToDoListDbContext toDoListDbContext)
    {
        this._toDoListDbContext = toDoListDbContext;
    }

    public IReadOnlyList<Bucket> GetAllBuckets()
    {
        var buckets = _toDoListDbContext.Buckets!.ToList();

        return buckets;
    }

    public Bucket GetBucket(int bucketId)
    {
        return _toDoListDbContext.Buckets!.First(a => a.Id == bucketId);
    }

    public void DeleteBucket(int bucketId)
    {
        var bucketToDelete = _toDoListDbContext.Buckets!.First(a => a.Id == bucketId);
        _toDoListDbContext.Buckets!.Remove(bucketToDelete);
        _toDoListDbContext.SaveChanges();
    }

    public int InsertBucket(Bucket bucket)
    {
        _toDoListDbContext.Buckets!.Add(bucket);
        _toDoListDbContext.SaveChanges();

        return bucket.Id;
    }

    public void UpdateBucket(int id, Bucket bucket)
    {
        var bucketToUpdate = _toDoListDbContext.Buckets!.First(a => a.Id == id);

        bucketToUpdate.Name = bucket.Name;
        bucketToUpdate.Description = bucket.Description;
        bucketToUpdate.Category = bucket.Category;
        bucketToUpdate.BucketColor = bucket.BucketColor;
        bucketToUpdate.MaxAmountOfTasks = bucket.MaxAmountOfTasks;
        bucketToUpdate.IsActive = bucket.IsActive;

        _toDoListDbContext.Buckets!.Update(bucketToUpdate);
        _toDoListDbContext.SaveChanges();
    }
}