using System.Collections.Generic;

namespace ToDoList.Api.Asignee.Models
{
    public class AssigneeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Domain.Models.BucketTask>? Tasks { get; set; }
    }
}
