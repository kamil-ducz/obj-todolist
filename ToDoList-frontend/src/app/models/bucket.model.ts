export class Bucket {
    public name: string;
    public description: string;
    public category: string;
    public bucketColor: string;
    public maxAmountOfTasks: number;
    public isActive: boolean;

    // wondering that image variables in this model could represent current size of a card which is actually bucket in the app
    // because depending on number of bucket task assigned to the bucket and thus a card in the app - this very card should be resizing accordingly
    public imagePath: string;
    public imageWidth: number;
    public imageHeight: number;

    constructor(name:string, description:string, imagePath:string, imageWidth: number, imageHeight: number, category: string, bucketColor: string, maxAmountOfTasks: number,
        isActive: boolean)
    {
        this.name = name;
        this.description = description;
        this.imagePath = imagePath;
        this.category = category;
        this.bucketColor = bucketColor;
        this.maxAmountOfTasks = maxAmountOfTasks;
        this.isActive = isActive;
        this.imageWidth = imageWidth;
        this.imageHeight = imageHeight;
    }
}

// C# model
// public class BucketDTO
// {
//     public int Id { get; set; }
//     public string? Name { get; set; }
//     public string? Description { get; set; }
//     public Category Category { get; set; }
//     public BucketColor BucketColor { get; set; }
//     public int MaxAmountOfTasks { get; set; }
//     public bool IsActive { get; set; }
//     public virtual List<BucketTaskDTO>? BucketTasks { get; set; }    SHOULD MOVE THIS TO ANGULAR SOMEHOW?
// }