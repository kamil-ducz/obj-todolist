using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces
{
    public interface IBucketTaskService
    {
        List<BucketTask> GetAllTasks();
        BucketTask GetBucketTask(int taskId);
        int InsertBucketTask(int taskId);
        void DeleteBucketTask(int taskId);
        void UpdateBucketTask(int taskId);
    }
}
