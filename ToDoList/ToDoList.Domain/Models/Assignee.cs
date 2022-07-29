namespace ToDoList.Domain.Models
{
    public class Assignee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TaskId { get; set; }
    }
}
