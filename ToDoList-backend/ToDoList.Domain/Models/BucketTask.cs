namespace ToDoList.Domain.Models;

public class BucketTask
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public BucketTaskState? BucketTaskState { get; set; }
    public int BucketTaskStateId { get; set; }
    public BucketTaskPriority? BucketTaskPriority { get; set; }
    public int BucketTaskPriorityId { get; set; }
    public Bucket? Bucket { get; set; }
    public int BucketId { get; set; }
    public Assignee? Assignee { get; set; }
    public int AssigneeId { get; set; }
}
