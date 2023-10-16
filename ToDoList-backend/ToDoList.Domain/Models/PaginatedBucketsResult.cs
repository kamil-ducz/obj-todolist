using System.Collections.Generic;

namespace ToDoList.Domain.Models;
public class PaginatedBucketsResult
{
    public int TotalBuckets { get; set; } // count all bucket records
    public int TotalPages { get; set; } // divide all bucket records by items per page
    public int StartPage { get; set; }
    public int EndPage { get; set; }
    public int CurrentPage { get; set; }
    public IReadOnlyCollection<Bucket> BucketsBatch { get; set; } = new List<Bucket>();
}
