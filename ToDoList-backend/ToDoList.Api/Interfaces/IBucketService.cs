using System.Collections.Generic;
using ToDoList.Api.Bucket.Models;

namespace ToDoList.Api.Interfaces
{
    public interface IBucketService
    {
        List<Domain.Models.Bucket> GetAllBuckets();
        Domain.Models.Bucket GetBucket(int bucketId);
        IEnumerable<Domain.Models.BucketTask> GetAllBucketsTasks(int bucketId);
        int InsertBucket(BucketDTO bucket);
        void DeleteBucket(int bucketId);
        void UpdateBucket(int id, BucketDTO bucket);
    }
}
