using System.Collections.Generic;
using System.Linq;
using ToDoList.Domain.Enums;

namespace ToDoList.Api
{
    public class ToDoListSeeder
    {
        private readonly ToDoListDbContext toDoListDbContext;

        public ToDoListSeeder(ToDoListDbContext toDoListDbContext)
        {
            this.toDoListDbContext = toDoListDbContext;
        }

        public void Seed()
        {
            if (toDoListDbContext.Database.CanConnect())
            {
                if (toDoListDbContext.Stats is not null && !toDoListDbContext.Stats.Any())
                {
                    var stats = GetStats();
                    toDoListDbContext.AddRange(stats);
                    toDoListDbContext.SaveChanges();
                }

                if (toDoListDbContext.Assignees is not null && !toDoListDbContext.Assignees.Any())
                {
                    var assignees = GetAssignees();
                    toDoListDbContext.AddRange(assignees);
                    toDoListDbContext.SaveChanges();
                }

                if (toDoListDbContext.Buckets is not null && !toDoListDbContext.Buckets.Any())
                {
                    var buckets = GetBuckets();
                    toDoListDbContext.AddRange(buckets);
                    toDoListDbContext.SaveChanges();
                }

                if (toDoListDbContext.BucketTasks is not null && !toDoListDbContext.BucketTasks.Any())
                {
                    var bucketTasks = GetBucketTasks();
                    toDoListDbContext.AddRange(bucketTasks);
                    toDoListDbContext.SaveChanges();
                }


            }
        }

        private IEnumerable<Domain.Models.Assignee> GetAssignees()
        {
            var assignees = new List<Domain.Models.Assignee>()
        {
            new Domain.Models.Assignee() { Name = "John", StatsId = 1},
            new Domain.Models.Assignee() { Name = "Elle", StatsId = 2},
        };

            return assignees;
        }

        private IEnumerable<Domain.Models.Bucket> GetBuckets()
        {
            var buckets = new List<Domain.Models.Bucket>()
        {
            new Domain.Models.Bucket() { Name = "bucket1", Description = "this is a sample description", BucketColor = Domain.Enums.Enums.BucketColor.Blue },
            new Domain.Models.Bucket() { Name = "bucket2", Description = "lol", BucketColor = Enums.BucketColor.Red },
            new Domain.Models.Bucket() { Name = "bucket3", BucketColor = Enums.BucketColor.Yellow },
        };

            return buckets;
        }

        private IEnumerable<Domain.Models.BucketTask> GetBucketTasks()
        {
            var bucketTasks = new List<Domain.Models.BucketTask>()
        {
            new Domain.Models.BucketTask() { Name = "some task", Description = "Sample description", TaskState = Enums.TaskState.InProgress, TaskPriority = Enums.TaskPriority.Low },
            new Domain.Models.BucketTask() { Name = "another task", Description = "This was something important :)", TaskState = Enums.TaskState.Done, TaskPriority = Enums.TaskPriority.Low },
            new Domain.Models.BucketTask() { Name = "simple task", Description = "Few little chores to go", TaskState = Enums.TaskState.Done, TaskPriority = Enums.TaskPriority.Low },
            new Domain.Models.BucketTask() { Name = "todo task", Description = "Important for John", TaskState = Enums.TaskState.ToDo, TaskPriority = Enums.TaskPriority.Low },
            new Domain.Models.BucketTask() { Name = "good task", Description = "Sync with Dawid xD", TaskState = Enums.TaskState.ToDo, TaskPriority = Enums.TaskPriority.Low },
        };

            return bucketTasks;
        }

        private IEnumerable<Domain.Models.Stats> GetStats()
        {
            var stats = new List<Domain.Models.Stats>()
        {
            new Domain.Models.Stats() { PercentOfTasksCancelled = 0, PercentOfTasksCompleted = 0, PercentOfTasksInProgress = 100, PercentOfTasksToDo = 0 },
            new Domain.Models.Stats() { PercentOfTasksCancelled = 0, PercentOfTasksCompleted = 100, PercentOfTasksInProgress = 0, PercentOfTasksToDo = 0 }
        };

            return stats;
        }
    }
}
