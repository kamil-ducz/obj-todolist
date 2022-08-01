using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Repositories
{
    public class BucketTaskRepository : IBucketTask
    {
        public List<BucketTask> GetAllTasks()
        {
            return Database.GetAllBucketTasks();
        }

        public BucketTask GetTask(int taskId)
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
