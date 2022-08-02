using System.Collections.Generic;

namespace ToDoList.Api.Interfaces
{
    public interface IBucketTaskService
    {
        List<Domain.Models.BucketTask> GetBucketTasks();
        Domain.Models.BucketTask GetBucketTask(int taskId);
        int InsertBucketTask(int taskId);
        void DeleteBucketTask(int taskId);
        void UpdateBucketTask(int taskId);
    }
}
