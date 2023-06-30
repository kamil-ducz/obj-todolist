using System.Collections.Generic;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Repositories;
public interface IBucketColorRepository
{
    IReadOnlyList<BucketColor> GetAllBucketColors();
    int GetBucketColorIdByName(string bucketColorName);
    string GetBucketColorNameById(int bucketColorId);
}
