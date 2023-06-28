using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;

public interface IBucketRepository
{
    IReadOnlyList<Buckets> GetAllBuckets();
    Buckets GetBucket(int bucketId);
    void InsertBucket(Buckets bucket);
    void DeleteBucket(Buckets bucket);
    void UpdateBucket(Buckets bucket);
}
