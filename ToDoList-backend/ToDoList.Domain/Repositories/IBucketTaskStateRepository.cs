using System.Collections.Generic;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Repositories;
public interface IBucketTaskStateRepository
{
    IReadOnlyList<BucketTaskState> GetAllBucketTaskStates();
}
