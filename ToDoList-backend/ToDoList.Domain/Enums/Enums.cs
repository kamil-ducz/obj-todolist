namespace ToDoList.Domain.Enums;

public class Enums
{
    // bucket enums

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

    // task enums

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
