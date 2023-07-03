using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;
public interface IBucketTaskStateRepository
{
    IReadOnlyCollection<BucketTaskState> GetAllBucketTaskStates();
}
