using System.Collections.Generic;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;
public interface IBucketCategoryRepository
{
    IReadOnlyList<BucketCategory> GetAllBucketCategories();
    BucketCategory GetBucketCategoryByName(string bucketCategoryName);
    BucketCategory GetBucketCategoryById(int bucketCategoryId);
}
