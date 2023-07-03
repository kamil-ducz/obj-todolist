using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.BucketTasks.Services;

public interface IBucketTaskService
{
    List<BucketTaskDto> GetBucketTasks();
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

    public int InsertBucketTask(BucketUpsertTaskDto bucketTaskDTO)
    {
        var mappedBucketTask = _mapper.Map<Domain.Models.BucketTask>(bucketTaskDTO);
        _bucketTaskRepository.InsertBucketTask(mappedBucketTask);

        return mappedBucketTask.Id;
    }

    public void UpdateBucketTask(int bucketTaskId, BucketUpsertTaskDto bucketTaskDTO)
    {
        var mappedBucketTask = _mapper.Map<Domain.Models.BucketTask>(bucketTaskDTO);
        mappedBucketTask.Id = bucketTaskId;

        _bucketTaskRepository.UpdateBucketTask(mappedBucketTask);
    }
}
