using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Interfaces;

public interface IBucketTaskService
{
    List<BucketTaskDto> GetBucketTasks();
    BucketTaskDto GetBucketTask(int taskId);
    void InsertBucketTask(BucketInsertTaskDto task);
    void DeleteBucketTask(int taskId);
    void UpdateBucketTask(int id, BucketInsertTaskDto bucketTask);
}
