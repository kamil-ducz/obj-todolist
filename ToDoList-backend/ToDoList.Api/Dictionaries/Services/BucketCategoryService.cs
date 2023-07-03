using System.Collections.Generic;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Dictionaries.Services;

public interface IBucketCategoryService
{
    IReadOnlyCollection<BucketCategory> GetAllBucketCategories();
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
}
