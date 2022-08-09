using System.Collections.Generic;
using static ToDoList.Domain.Enums.Enums;

namespace ToDoList.Api.Bucket.Models
{
    public class BucketDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public int AssigneeId { get; set; }
        public virtual Domain.Models.Assignee Assignee { get; set; }
        public Category Category { get; set; }
        public BucketColor BucketColor { get; set; }
        public List<Domain.Models.BucketTask>? Tasks { get; set; }
        public bool IsActive { get; set; }
    }
}
