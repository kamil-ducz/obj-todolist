using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;
public interface IBucketColorRepository
{
    IReadOnlyList<BucketColor> GetAllBucketColors();
}
