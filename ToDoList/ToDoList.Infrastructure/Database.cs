using ToDoList.Domain.Enums;
using ToDoList.Domain.Models;

namespace ToDoList.Api
{
    public static class Database
    {
        static List<Bucket> BucketList = new List<Bucket>()
        {
            new Bucket() { Id = 1, Name = "bucket1", BucketColor = Domain.Enums.Enums.BucketColor.Blue },
            new Bucket() { Id = 2, Name = "bucket2", BucketColor = Enums.BucketColor.Red },
            new Bucket() { Id = 3, Name = "bucket3", BucketColor = Enums.BucketColor.Yellow },
        };

        public static Bucket GetBucket(int id)
        {
            return BucketList.First(b => b.Id == id);
        }

        public static List<Bucket> GetAllBuckets()
        {
            return BucketList;
        }

        static List<BucketTask> BucketTaskList = new List<BucketTask>()
        {
            new BucketTask() { Id = 1, BucketId = 2, Name = "some task", Description = "Sample description", TaskState = Enums.TaskState.InProgress, TaskPriority = Enums.TaskPriority.Low },
            new BucketTask() { Id = 2, BucketId = 2, Name = "another task", Description = "This was something important :)", TaskState = Enums.TaskState.Done, TaskPriority = Enums.TaskPriority.Low },
            new BucketTask() { Id = 3, BucketId = 1, Name = "simple task", Description = "Few little chores to go", TaskState = Enums.TaskState.Done, TaskPriority = Enums.TaskPriority.Low },
            new BucketTask() { Id = 4, BucketId = 3, Name = "todo task", Description = "Important for John", TaskState = Enums.TaskState.ToDo, TaskPriority = Enums.TaskPriority.Low },
            new BucketTask() { Id = 5, Name = "good task", Description = "Sync with Dawid xD", TaskState = Enums.TaskState.ToDo, TaskPriority = Enums.TaskPriority.Low },
        };

        public static List<BucketTask> GetAllBucketTasks()
        {
            return BucketTaskList;
        }

        public static BucketTask GetBucketTask(int id)
        {
            return BucketTaskList.First(t => t.Id == id);
        }

        static List<Assignee> Assignees = new List<Assignee>()
        {
            new Assignee() { Id = 1, Name = "John", BucketTaskId = 1},
            new Assignee() { Id = 2, Name = "Elle", BucketTaskId = 3},
        };

        public static List<Assignee> GetAllAssigness()
        {
            return Assignees;
        }

        public static Assignee GetAssignee(int id)
        {
            return Assignees.First(a => a.Id == id);
        }

        static List<Stats> Stats = new List<Stats>()
        {
            new Stats() { Id = 1, AsigneeId = 1, PercentOfTasksCancelled = 0, PercentOfTasksCompleted = 0, PercentOfTasksInProgress = 100, PercentOfTasksToDo = 0 },
            new Stats() { Id = 2, AsigneeId = 2, PercentOfTasksCancelled = 0, PercentOfTasksCompleted = 100, PercentOfTasksInProgress = 0, PercentOfTasksToDo = 0 }
        };

        public static List<Stats> GetAllStats()
        {
            return Stats;
        }

        public static Stats GetStats(int id)
        {
            return Stats.First(s => s.Id == id);
        }
    }
}
