using ToDoList.Api;
using ToDoList.Domain.Models;
using ToDoList.Infrastructure.Interfaces;

namespace ToDoList.Infrastructure.Repositories
{
    public class BucketTaskRepository : IBucketTaskRepository
    {
        public List<BucketTask> GetAllTasks()
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

        public int InsertBucketTask(int taskId)
        {
            throw new NotImplementedException();
        }

        public void UpdateBucketTask(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
