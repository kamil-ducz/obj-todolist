namespace ToDoList.Domain.Enums;

public class Enums
{
    public enum Category
    {
        Home,
        Job,
        Hobby
    }

    public enum BucketColor
    {
        Brown,
        Red,
        Yellow,
        Blue,
        White,
        Green
    }

    public enum TaskState
    {
        ToDo,
        InProgress,
        Done,
        Cancelled
    }

    public enum TaskPriority
    {
        High,
        Normal,
        Low
    }
}
