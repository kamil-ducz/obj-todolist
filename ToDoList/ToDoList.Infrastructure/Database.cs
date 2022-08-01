using ToDoList.Domain.Models;

namespace ToDoList.Api
{
    public static class Database
    {
        public static Bucket? Bucket { get; set; }
        public static BucketTask? BucketTask { get; set; }
        public static Assignee? Assignee { get; set; }
        public static Stats? Stats { get; set; }

        public static void DoSomething()
        {
            int a = 1;
            int b = a;
        }

    }
}
