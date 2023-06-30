using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Dictionaries.Services;

public interface IBucketColorService
{
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
    public int GetBucketColorIdByName(string bucketColorName)
    {
        return _bucketColorRepository.GetBucketColorIdByName(bucketColorName);
    }

    public string GetBucketColorNameById(int bucketColorId)
    {
        return _bucketColorRepository.GetBucketColorNameById(bucketColorId);
    }
}
