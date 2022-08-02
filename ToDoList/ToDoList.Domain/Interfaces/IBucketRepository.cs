using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces
{
    public interface IBucketRepository
    {
        List<Bucket> GetAllBuckets();
        Bucket GetBucket(int bucketId);
        int InsertBucket(Bucket bucket);
        void DeleteBucket(Bucket bucket);
        void UpdateBucket(Bucket bucket);
    }
}
