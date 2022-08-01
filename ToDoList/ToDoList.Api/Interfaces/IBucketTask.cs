using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces
{
    public interface IBucketTask
    {
        List<BucketTask> GetAllTasks();
        BucketTask GetTask(int taskId);
        int InsertBucketTask(int taskId);
        void DeleteBucketTask(int taskId);
        void UpdateBucketTask(int taskId);
    }
}
