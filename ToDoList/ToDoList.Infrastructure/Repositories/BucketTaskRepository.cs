using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Repositories
{
    public class BucketTaskRepository : IBucketTaskRepository
    {
        public List<BucketTask> GetAllBucketTasks()
        {
            return Database.GetAllBucketTasks();
        }

        public BucketTask GetBucketTask(int taskId)
        {
            return Database.GetBucketTask(taskId);
        }

        public void DeleteBucketTask(int taskId)
        {
            throw new NotImplementedException();
        }

        public int InsertBucketTask(BucketTask task)
        {
            throw new NotImplementedException();
        }

        public void UpdateBucketTask(BucketTask task)
        {
            throw new NotImplementedException();
        }
    }
}
