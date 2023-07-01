using System.Collections.Generic;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Dictionaries.Services;

public interface IBucketColorService
{
    IReadOnlyCollection<BucketColor> GetAllBucketColors();
    int GetBucketColorIdByName(string bucketColorName);
    string GetBucketColorNameById(int bucketColorId);
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

    public int GetBucketColorIdByName(string bucketColorName)
    {
        return _bucketColorRepository.GetBucketColorIdByName(bucketColorName);
    }

    public string GetBucketColorNameById(int bucketColorId)
    {
        return _bucketColorRepository.GetBucketColorNameById(bucketColorId);
    }
}
