using System.Collections.Generic;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;
public interface IBucketColorRepository
{
    IReadOnlyList<BucketColor> GetAllBucketColors();
    int GetBucketColorIdByName(string bucketColorName);
    string GetBucketColorNameById(int bucketColorId);
}
