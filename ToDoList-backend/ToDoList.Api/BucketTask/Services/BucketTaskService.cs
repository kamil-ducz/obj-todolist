using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Api.Interfaces;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.BucketTask.Services;

public class BucketTaskService : IBucketTaskService
{
    private readonly IBucketTaskRepository _bucketTaskRepository;
    private readonly IMapper _mapper;

    public BucketTaskService(IBucketTaskRepository bucketTaskRepository, IMapper mapper)
    {
        _bucketTaskRepository = bucketTaskRepository;
        _mapper = mapper;
    }

    public List<BucketTaskDto> GetBucketTasks()
    {
        return _mapper.Map<List<BucketTaskDto>>(_bucketTaskRepository.GetAllBucketTasks());
    }

    public BucketTaskDto GetBucketTask(int taskId)
    {
        return _mapper.Map<BucketTaskDto>(_bucketTaskRepository.GetBucketTask(taskId));
    }

    public void DeleteBucketTask(int taskId)
    {
        var bucketTaskToDelete = _bucketTaskRepository.GetAllBucketTasks().First(t => t.Id == taskId);
        _bucketTaskRepository.DeleteBucketTask(bucketTaskToDelete);
    }

    public void InsertBucketTask(BucketInsertTaskDto bucketTaskDTO)
    {
        var mappedBucketTask = _mapper.Map<Domain.Models.BucketTask>(bucketTaskDTO);

        _bucketTaskRepository.InsertBucketTask(mappedBucketTask);
    }

    public void UpdateBucketTask(int bucketTaskId, BucketInsertTaskDto bucketTaskDTO)
    {
        var bucketTaskToUpdate = _bucketTaskRepository.GetAllBucketTasks().First(a => a.Id == bucketTaskId);

        var mappedBucketTask = _mapper.Map<Domain.Models.BucketTask>(bucketTaskDTO);

        _bucketTaskRepository.UpdateBucketTask(mappedBucketTask);
    }
}
