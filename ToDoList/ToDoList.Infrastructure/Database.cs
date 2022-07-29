using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure
{
    public static class Database
    {
        public static Bucket? Bucket { get; set; }
        public static BucketTask? BucketTask { get; set; }
        public static Assignee? Assignee { get; set; }
        public static Stats? Stats { get; set; }
    }
}
