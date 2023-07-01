using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;

public interface IBucketTaskRepository
{
    IReadOnlyList<BucketTask> GetAllBucketTasks();
    BucketTask GetBucketTask(int taskId);
    void InsertBucketTask(BucketTask task);
    void DeleteBucketTask(BucketTask task);
    void UpdateBucketTask(BucketTask task);
}
