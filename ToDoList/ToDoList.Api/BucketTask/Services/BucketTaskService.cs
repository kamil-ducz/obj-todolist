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
        private readonly ToDoListDbContext toDoListDbContext;
        private readonly IMapper mapper;

        public BucketTaskService(IBucketTaskRepository bucketTaskRepository, ToDoListDbContext toDoListDbContext, IMapper mapper)
        {
            this.bucketTaskRepository = bucketTaskRepository;
            this.toDoListDbContext = toDoListDbContext;
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
            throw new System.NotImplementedException();
        }

        public int InsertBucketTask(BucketTaskDTO bucketTaskDTO)
        {
            if (toDoListDbContext.BucketTasks is not null)
            {
                var mappedBucketTask = mapper.Map<Domain.Models.BucketTask>(bucketTaskDTO);

                toDoListDbContext.BucketTasks.Add(mappedBucketTask);
                toDoListDbContext.SaveChanges();
            }

            return bucketTaskDTO.Id;
        }

        public void UpdateBucketTask(Domain.Models.BucketTask task)
        {
            throw new System.NotImplementedException();
        }
    }
}
