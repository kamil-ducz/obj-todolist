using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;

public interface IBucketColorRepository
{
    IReadOnlyList<BucketColor> GetAllBucketColors();
    BucketColor GetBucketColorByName(string bucketColorName);
    BucketColor GetBucketColorById(int bucketColorId);
}
