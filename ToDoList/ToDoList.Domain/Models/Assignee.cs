using System.Collections.Generic;

namespace ToDoList.Domain.Models
{
    public class Assignee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<BucketTask>? Tasks { get; set; }
    }
}
