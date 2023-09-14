using System.Collections.Generic;

namespace ToDoList.Domain.Models;
public class PaginatedBucketsResult
{
    public int totalBuckets { get; set; } // count all bucket records
    public int totalPages { get; set; } // divide all bucket records by items per page
    public int startPage { get; set; }
    public int endPage { get; set; }
    //public Tuple<int, int> pagesRange { get; set; } // alternative to pages range to check 

    public List<Bucket> bucketsBatch { get; set; } = new List<Bucket>();
}
