export class BucketTask {
    public name: string;
    public description: string;
    public taskState: number;
    public taskPriority: number;

    // wondering that in this model 
    // imageWidth and imageHeight variables should rather have fixed values all the time
    // imagePath should change depending what color we want to have at the moment
    public imagePath: string;
    public imageWidth: number;
    public imageHeight: number;

    constructor(name:string, description:string, taskState: number, taskPriority: number, imagePath:string, imageWidth: number, imageHeight: number)
    {
        this.name = name;
        this.description = description;
        this.taskState  = taskState;
        this.taskPriority = taskPriority;
        this.imagePath = imagePath;
        this.imageWidth = imageWidth;
        this.imageHeight = imageHeight;
    }
}

//C# model
// public class BucketTaskDTO
// {
//     public int Id { get; set; }
//     public string? Name { get; set; }
//     public string? Description { get; set; }
//     public TaskState TaskState { get; set; }
//     public TaskPriority TaskPriority { get; set; }
//     public virtual List<AssigneeDTO>? Assignees { get; set; }    SHOULD MOVE THIS TO ANGULAR SOMEHOW?

// }