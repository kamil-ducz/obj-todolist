using System.Collections.Generic;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Dictionaries.Services;

public interface IBucketColorService
{
    IReadOnlyCollection<BucketColor> GetAllBucketColors();
    BucketColor GetBucketColorByName(string bucketColorName);
    BucketColor GetBucketColorById(int bucketColorId);
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

    public BucketColor GetBucketColorByName(string bucketColorName)
    {
        return _bucketColorRepository.GetBucketColorByName(bucketColorName);
    }

    public BucketColor GetBucketColorById(int bucketColorId)
    {
        return _bucketColorRepository.GetBucketColorById(bucketColorId);
    }
}
