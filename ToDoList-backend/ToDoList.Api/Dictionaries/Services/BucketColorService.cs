using System.Collections.Generic;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Dictionaries.Services;

public interface IBucketColorService
{
    IReadOnlyCollection<BucketColor> GetAllBucketColors();
}

public class BucketColorService : IBucketColorService
{
    private readonly IBucketColorRepository _bucketColorRepository;

    public BucketColorService(IBucketColorRepository bucketColorRepository)
    {
        _bucketColorRepository = bucketColorRepository;
    }

    public IReadOnlyCollection<BucketColor> GetAllBucketColors()
    {
        return _bucketColorRepository.GetAllBucketColors();
    }
}
