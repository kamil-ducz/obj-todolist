using System.Collections.Generic;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Dictionaries.Services;

public interface IBucketCategoryService
{
    IReadOnlyCollection<BucketCategory> GetAllBucketCategories();
    BucketCategory GetBucketCategoryByName(string bucketCategoryName);
    BucketCategory GetBucketCategoryById(int bucketCategoryId);
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

    public BucketCategory GetBucketCategoryByName(string bucketCategoryName)
    {
        return _bucketCategoryRepository.GetBucketCategoryByName(bucketCategoryName);
    }

    public BucketCategory GetBucketCategoryById(int bucketCategoryId)
    {
        return _bucketCategoryRepository.GetBucketCategoryById(bucketCategoryId);
    }
}
