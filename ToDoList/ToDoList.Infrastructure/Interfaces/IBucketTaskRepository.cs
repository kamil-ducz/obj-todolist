using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Interfaces
{
    public interface IBucketTaskRepository
    {
        List<BucketTask> GetAllTasks();
        BucketTask GetBucketTask(int taskId);
        int InsertBucketTask(int taskId);
        void DeleteBucketTask(int taskId);
        void UpdateBucketTask(int taskId);
    }
}
