using System.Collections.Generic;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.BucketTask.Services
{
    public class BucketTaskService : IBucketTaskService
    {
        private readonly IBucketTaskService bucketTaskService;

        public BucketTaskService(IBucketTaskService bucketTaskService)
        {
            this.bucketTaskService = bucketTaskService;
        }

        public List<Domain.Models.BucketTask> GetAllTasks()
        {
            return bucketTaskService.GetAllTasks();
        }

        public Domain.Models.BucketTask GetBucketTask(int taskId)
        {
            return bucketTaskService.GetBucketTask(taskId);
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
