using System.Collections.Generic;
using ToDoList.Api.Bucket.Models;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Interfaces;

public interface IBucketService
{
    List<BucketDto> GetAllBuckets();
    BucketDto GetBucket(int bucketId);
    IEnumerable<BucketTaskDto> GetAllBucketsTasks(int bucketId);
    int InsertBucket(BucketDto bucket);
    void DeleteBucket(int bucketId);
    void UpdateBucket(int id, BucketDto bucket);
}
