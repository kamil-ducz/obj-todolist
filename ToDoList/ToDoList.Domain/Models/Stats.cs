namespace ToDoList.Domain.Models
{
    public class Stats
    {
        public int Id { get; set; }
        public int AsigneeId { get; set; }
        public decimal PercentOfTasksCompleted { get; set; }
        public decimal PercentOfTasksToDo { get; set; }
        public decimal PercentOfTasksInProgress { get; set; }
        public decimal PercentOfTasksCancelled { get; set; }
    }
}
