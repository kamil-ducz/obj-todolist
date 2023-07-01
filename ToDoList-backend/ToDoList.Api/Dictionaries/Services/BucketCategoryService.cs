using System.Collections.Generic;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Dictionaries.Services;

public interface IBucketCategoryService
{
    IReadOnlyCollection<BucketCategory> GetAllBucketCategories();
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

    public IReadOnlyCollection<BucketCategory> GetAllBucketCategories()
    {
        return _bucketCategoryRepository.GetAllBucketCategories();
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
