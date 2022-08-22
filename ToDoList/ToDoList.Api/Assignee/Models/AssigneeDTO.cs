using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Asignee.Models
{
    public class AssigneeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BucketTaskId { get; set; }
        public virtual BucketTaskDTO? BucketTask { get; set; }
    }
}
