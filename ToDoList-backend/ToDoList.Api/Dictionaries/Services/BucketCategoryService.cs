using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Dictionaries.Services;

public interface IBucketCategoryService
{
    int GetBucketCategoryIdByName(string bucketCategoryName);
    string GetBucketCategoryNameById(int bucketCategoryId);
}

public class BucketCategoryService : IBucketCategoryService
{
    private readonly IBucketCategoryRepository _bucketCategoryRepository;

    public BucketCategoryService(IBucketCategoryRepository bucketCategoryRepository)
    {
        _bucketCategoryRepository = bucketCategoryRepository;
    }
    public int GetBucketCategoryIdByName(string bucketCategoryName)
    {
        return _bucketCategoryRepository.GetBucketCategoryIdByName(bucketCategoryName);
    }

    public string GetBucketCategoryNameById(int bucketCategoryId)
    {
        return _bucketCategoryRepository.GetBucketCategoryNameById(bucketCategoryId);
    }
}
