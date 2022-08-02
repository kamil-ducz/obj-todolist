using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Interfaces
{
    public interface IBucketRepository
    {
        List<Bucket> GetAllBuckets();
        Bucket GetBucket(int bucketId);
        int InsertBucket(int bucketId);
        void DeleteBucket(int bucketId);
        void UpdateBucket(int bucketId);
    }
}
