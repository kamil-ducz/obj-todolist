using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;

public interface IBucketTaskRepository
{
    IReadOnlyList<BucketTasks> GetAllBucketTasks();
    BucketTasks GetBucketTask(int taskId);
    void InsertBucketTask(BucketTasks task);
    void DeleteBucketTask(BucketTasks task);
    void UpdateBucketTask(BucketTasks task);
}
