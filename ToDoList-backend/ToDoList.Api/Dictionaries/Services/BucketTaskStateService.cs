using System.Collections.Generic;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Dictionaries.Services;

public interface IBucketTaskStateService
{
    IReadOnlyCollection<BucketTaskState> GetAllBucketTasksStates();
}

public class BucketTaskStateService : IBucketTaskStateService
{
    private readonly IBucketTaskStateRepository _bucketTaskStateRepository;

    public BucketTaskStateService(IBucketTaskStateRepository bucketTaskStateRepository)
    {
        _bucketTaskStateRepository = bucketTaskStateRepository;
    }
    public IReadOnlyCollection<BucketTaskState> GetAllBucketTasksStates()
    {
        return _bucketTaskStateRepository.GetAllBucketTaskStates();
    }
}
