using AutoMapper;
using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Api.Interfaces;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.BucketTask.Services
{
    public class BucketTaskService : IBucketTaskService
    {
        private readonly IBucketTaskRepository bucketTaskRepository;
        private readonly IMapper mapper;

        public BucketTaskService(IBucketTaskRepository bucketTaskRepository, IMapper mapper)
        {
            this.bucketTaskRepository = bucketTaskRepository;
            this.mapper = mapper;
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
            bucketTaskRepository.DeleteBucketTask(taskId);
        }

        public int InsertBucketTask(BucketTaskDTO bucketTaskDTO)
        {
            var mappedBucketTask = mapper.Map<Domain.Models.BucketTask>(bucketTaskDTO);

            return bucketTaskRepository.InsertBucketTask(mappedBucketTask);
        }

        public void UpdateBucketTask(Domain.Models.BucketTask task)
        {
            throw new System.NotImplementedException();
        }
    }
}
