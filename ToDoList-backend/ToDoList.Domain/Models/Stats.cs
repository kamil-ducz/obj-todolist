namespace ToDoList.Domain.Models
{
    public class Stats
    {
        public int Id { get; set; }
        public decimal Completed { get; set; }
        public decimal ToDo { get; set; }
        public decimal InProgress { get; set; }
        public decimal Cancelled { get; set; }
        public virtual Assignee? Assignee { get; set; }
    }
}
