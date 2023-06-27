using System.Collections.Generic;
using ToDoList.Api.Bucket.Models;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Interfaces;

public interface IBucketService
{
    IReadOnlyCollection<BucketDto> GetAllBuckets();
    BucketDto GetBucket(int bucketId);
    IReadOnlyCollection<BucketTaskDto> GetAllBucketsTasks(int bucketId);
    int InsertBucket(BucketInsertDto bucket);
    void DeleteBucket(int bucketId);
    void UpdateBucket(int id, BucketInsertDto bucket);
}
