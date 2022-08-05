using System.Collections.Generic;

namespace ToDoList.Api.Interfaces
{
    public interface IBucketTaskService
    {
        List<Domain.Models.BucketTask> GetBucketTasks();
        Domain.Models.BucketTask GetBucketTask(int taskId);
        int InsertBucketTask(Domain.Models.BucketTask task);
        void DeleteBucketTask(int taskId);
        void UpdateBucketTask(Domain.Models.BucketTask task);
    }
}
