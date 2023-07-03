using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;
public interface IBucketCategoryRepository
{
    IReadOnlyList<BucketCategory> GetAllBucketCategories();
}
