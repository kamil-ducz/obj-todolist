using System.Collections.Generic;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.BucketTask.Services
{
    public class BucketTaskService
    {
        public IBucketTask BucketTaskRepository { get; }

        public BucketTaskService(IBucketTask bucketTaskRepository)
        {
            BucketTaskRepository = bucketTaskRepository;
        }

        public List<Domain.Models.BucketTask> GetBucketTasks()
        {
            return BucketTaskRepository.GetAllTasks();
        }

        public Domain.Models.BucketTask GetBucket(int id)
        {
            return BucketTaskRepository.GetTask(id);
        }

    }
}
