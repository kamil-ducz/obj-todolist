using AutoMapper;
using System.Collections.Generic;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.BucketTasks.Services;

public interface IBucketTaskService
{
    IReadOnlyCollection<BucketTaskDto> GetBucketTasks();
    BucketTaskDto GetBucketTask(int taskId);
    int InsertBucketTask(BucketUpsertTaskDto task);
    void DeleteBucketTask(int taskId);
    void UpdateBucketTask(int id, BucketUpsertTaskDto bucketTask);
}

public class BucketTaskService : IBucketTaskService
{
    private readonly IBucketTaskRepository _bucketTaskRepository;
    private readonly IMapper _mapper;

    public BucketTaskService(IBucketTaskRepository bucketTaskRepository, IMapper mapper)
    {
        _bucketTaskRepository = bucketTaskRepository;
        _mapper = mapper;
    }

    public IReadOnlyCollection<BucketTaskDto> GetBucketTasks()
    {
        return _mapper.Map<List<BucketTaskDto>>(_bucketTaskRepository.GetAllBucketTasks());
    }

    public BucketTaskDto GetBucketTask(int taskId)
    {
        return _mapper.Map<BucketTaskDto>(_bucketTaskRepository.GetBucketTask(taskId));
    }

    public void DeleteBucketTask(int taskId)
    {
        var bucketTaskToDelete = _bucketTaskRepository.GetBucketTask(taskId);
        _bucketTaskRepository.DeleteBucketTask(bucketTaskToDelete);
    }

    public int InsertBucketTask(BucketUpsertTaskDto bucketTaskDTO)
    {
        var bucketTask = _mapper.Map<BucketTask>(bucketTaskDTO);
        _bucketTaskRepository.InsertBucketTask(bucketTask);
        return bucketTask.Id;
    }

    public void UpdateBucketTask(int bucketTaskId, BucketUpsertTaskDto bucketTaskDTO)
    {
        var bucketTask = _bucketTaskRepository.GetBucketTask(bucketTaskId);
        _mapper.Map(bucketTaskDTO, bucketTask);
        _bucketTaskRepository.UpdateBucketTask(bucketTask);
    }
}
