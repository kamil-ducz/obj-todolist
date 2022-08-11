using System.Collections.Generic;

namespace ToDoList.Domain.Models
{
    public class Assignee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BucketTaskId { get; set; }
        public virtual List<BucketTask>? BucketTask { get; set; }

    }
}
