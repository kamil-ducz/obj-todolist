using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces;

public interface IBucketTaskRepository
{
    IReadOnlyList<BucketTask> GetAllBucketTasks();
    BucketTask GetBucketTask(int taskId);
    int InsertBucketTask(BucketTask task);
    void DeleteBucketTask(int taskId);
    void UpdateBucketTask(int id, BucketTask task);
}
