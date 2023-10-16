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

    public PaginatedBucketsResult GetPaginatedBucketsResult(string? searchPhrase, int currentPage = 1, int itemsPerPage = 10)
    {
        PaginatedBucketsResult result = new PaginatedBucketsResult();

        var query = _toDoListDbContext.Buckets.AsQueryable();

        if (!string.IsNullOrEmpty(searchPhrase))
        {
            var normalizedSearchPhrase = searchPhrase.ToLower();
            query = query.Where(b => b.Name.Contains(normalizedSearchPhrase));
            // If search phrase provided by client, return found results without pagination
            result.BucketsBatch = query.ToList();
            return result;
        }

        // Calculate total buckets (before applying pagination)
        result.TotalBuckets = query.Count();

        // Apply pagination
        result.BucketsBatch = query
            .OrderBy(b => b.Id) // You might want to order by a specific property
            .Skip((currentPage - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToList();

        // Calculate total pages
        result.TotalPages = (int)Math.Ceiling((double)result.TotalBuckets / itemsPerPage);

        result.CurrentPage = currentPage;

        return result;
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