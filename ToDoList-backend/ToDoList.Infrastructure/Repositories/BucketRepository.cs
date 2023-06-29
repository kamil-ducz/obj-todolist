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
        var buckets = _toDoListDbContext.Buckets!.ToList();
        foreach (var bucket in buckets)
        {
            bucket.BucketColor = _toDoListDbContext.BucketColor.First(bc => bc.Id == bucket.BucketColorId);
            bucket.BucketCategory = _toDoListDbContext.BucketCategory.First(bcat => bcat.Id == bucket.BucketCategoryId);
        }
        return buckets;
    }

    public Buckets GetBucket(int bucketId)
    {
        var bucket = _toDoListDbContext.Buckets!.First(a => a.Id == bucketId);
        {
            bucket.BucketColor = _toDoListDbContext.BucketColor.First(bc => bc.Id == bucket.BucketColorId);
            bucket.BucketCategory = _toDoListDbContext.BucketCategory.First(bcat => bcat.Id == bucket.BucketCategoryId);
        }
        return bucket;
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