using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;

public interface IBucketRepository
{
    IReadOnlyList<Bucket> GetAllBuckets();
    PaginatedBucketsResult GetPaginatedBucketsResult(string? searchPhrase, int currentPage, int itemsPerPage);
    Bucket GetBucket(int bucketId);
    void InsertBucket(Bucket bucket);
    void DeleteBucket(Bucket bucket);
    void UpdateBucket(Bucket bucket);
}
