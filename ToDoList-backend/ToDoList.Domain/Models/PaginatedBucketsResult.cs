using System.Collections.Generic;

namespace ToDoList.Domain.Models;
public class PaginatedBucketsResult<T>
{
    public int TotalBuckets { get; set; } // Count all bucket records
    public int TotalPages { get; set; } // Divide all bucket records by items per page
    public int CurrentPage { get; set; } // Provided by client or 1 by default
    public IReadOnlyCollection<T> BucketsBatch { get; set; } = new List<T>();
}
