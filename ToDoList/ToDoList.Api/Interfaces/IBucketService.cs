using System.Collections.Generic;

namespace ToDoList.Api.Interfaces
{
    public interface IBucketService
    {
        List<Domain.Models.Bucket> GetAllBuckets();
        Domain.Models.Bucket GetBucket(int bucketId);
        int InsertBucket(Domain.Models.Bucket bucket);
        void DeleteBucket(int bucketId);
        void UpdateBucket(Domain.Models.Bucket bucket);
    }
}
