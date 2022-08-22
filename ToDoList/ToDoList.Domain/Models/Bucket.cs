using System.Collections.Generic;
using static ToDoList.Domain.Enums.Enums;

namespace ToDoList.Domain.Models
{
    public class Bucket
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public int AssigneeId { get; set; }
        public virtual Assignee Assignee { get; set; }
        public Category Category { get; set; }
        public BucketColor BucketColor { get; set; }
        public int MaxAmountOfTasks { get; set; }
        public List<BucketTask>? Tasks { get; set; }
        public bool IsActive { get; set; }
    }
}
