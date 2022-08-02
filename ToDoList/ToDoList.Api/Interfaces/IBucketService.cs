using System.Collections.Generic;

namespace ToDoList.Api.Interfaces
{
    public interface IBucketService
    {
        List<Domain.Models.Bucket> GetAllBuckets();
        Domain.Models.Bucket GetBucket(int bucketId);
        int InsertBucket(int bucketId);
        void DeleteBucket(int bucketId);
        void UpdateBucket(int bucketId);
    }
}
