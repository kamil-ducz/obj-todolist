using System.Collections.Generic;
using ToDoList.Api.Interfaces;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.BucketTask.Services
{
    public class BucketTaskService : IBucketTaskService
    {
        private readonly IBucketTaskRepository bucketTaskRepository;

        public BucketTaskService(IBucketTaskRepository bucketTaskRepository)
        {
            this.bucketTaskRepository = bucketTaskRepository;
        }

        public List<Domain.Models.BucketTask> GetBucketTasks()
        {
            return bucketTaskRepository.GetAllBucketTasks();
        }

        public Domain.Models.BucketTask GetBucketTask(int taskId)
        {
            return bucketTaskRepository.GetBucketTask(taskId);
        }

        public void DeleteBucketTask(int taskId)
        {
            throw new System.NotImplementedException();
        }

        public int InsertBucketTask(int taskId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBucketTask(int taskId)
        {
            throw new System.NotImplementedException();
        }
    }
}
