using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces
{
    public interface IBucket
    {
        List<Bucket> GetAllBuckets();
        Bucket GetBucket(int bucketId);
        int InsertBucket(int bucketId);
        void DeleteBucket(int bucketId);
        void UpdateBucket(int bucketId);
    }
}
