using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Interfaces
{
    public interface IBucketTaskService
    {
        List<Domain.Models.BucketTask> GetBucketTasks();
        Domain.Models.BucketTask GetBucketTask(int taskId);
        int InsertBucketTask(BucketTaskDTO task);
        void DeleteBucketTask(int taskId);
        void UpdateBucketTask(Domain.Models.BucketTask task);
    }
}
