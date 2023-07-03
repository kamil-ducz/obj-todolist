using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;
public interface IBucketTaskPriorityRepository
{
    IReadOnlyCollection<BucketTaskPriority> GetAllBucketTaskPriorities();
}
