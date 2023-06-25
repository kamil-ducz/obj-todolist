using System.Collections.Generic;
using ToDoList.Api.Bucket.Models;

namespace ToDoList.Api.Interfaces;

public interface IBucketService
{
    List<BucketDto> GetAllBuckets();
    BucketDto GetBucket(int bucketId);
    IEnumerable<BucketDto> GetAllBucketsTasks(int bucketId);
    int InsertBucket(BucketDto bucket);
    void DeleteBucket(int bucketId);
    void UpdateBucket(int id, BucketDto bucket);
}
