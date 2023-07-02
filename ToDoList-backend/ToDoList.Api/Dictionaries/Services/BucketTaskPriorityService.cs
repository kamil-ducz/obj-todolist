using System.Collections.Generic;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Dictionaries.Services;

public interface IBucketTaskPriorityService
{
    IReadOnlyCollection<BucketTaskPriority> GetBucketTaskPriorities();
}

public class BucketTaskPriorityService : IBucketTaskPriorityService
{
    private readonly IBucketTaskPriorityRepository _bucketTaskPriorityRepository;

    public BucketTaskPriorityService(IBucketTaskPriorityRepository bucketTaskPriorityRepository)
    {
        _bucketTaskPriorityRepository = bucketTaskPriorityRepository;
    }
    public IReadOnlyCollection<BucketTaskPriority> GetBucketTaskPriorities()
    {
        return _bucketTaskPriorityRepository.GetAllBucketTaskPriorities();
    }
}
