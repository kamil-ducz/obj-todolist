using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Interfaces;

public interface IBucketTaskService
{
    List<BucketTaskDto> GetBucketTasks();
    BucketTaskDto GetBucketTask(int taskId);
    int InsertBucketTask(BucketTaskDto task);
    void DeleteBucketTask(int taskId);
    void UpdateBucketTask(int id, BucketTaskDto bucketTask);
}
