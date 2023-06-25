using AutoMapper;
using System.Collections.Generic;
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
        _bucketTaskRepository.DeleteBucketTask(taskId);
    }

    public int InsertBucketTask(BucketTaskDto bucketTaskDTO)
    {
        var mappedBucketTask = _mapper.Map<Domain.Models.BucketTask>(bucketTaskDTO);

        return _bucketTaskRepository.InsertBucketTask(mappedBucketTask);
    }

    public void UpdateBucketTask(int id, BucketTaskDto bucketTaskDTO)
    {
        var mappedBucketTask = _mapper.Map<Domain.Models.BucketTask>(bucketTaskDTO);

        _bucketTaskRepository.UpdateBucketTask(id, mappedBucketTask);
    }
}
