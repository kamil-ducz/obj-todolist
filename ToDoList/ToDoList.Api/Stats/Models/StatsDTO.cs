using ToDoList.Api.Asignee.Models;

namespace ToDoList.Api.Stats.Models
{
    public class StatsDTO
    {
        public int Id { get; set; }
        public int AsigneeId { get; set; }
        public virtual AssigneeDTO Assignee { get; set; }
    }
}
