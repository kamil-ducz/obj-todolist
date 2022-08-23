using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Api.Stats.Models;

namespace ToDoList.Api.Asignee.Models
{
    public class AssigneeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? StatsId { get; set; }
        public virtual StatsDTO? Stats { get; set; }
        public virtual List<BucketTaskDTO>? BucketTasks { get; set; }
    }
}
