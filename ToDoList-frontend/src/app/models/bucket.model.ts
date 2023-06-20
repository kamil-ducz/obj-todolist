export class Bucket {
    public name: string;
    public description: string;
    public category: number;
    public bucketColor: any;
    public maxAmountOfTasks: number;
    public isActive: boolean;
    public bucketTasks: any;

    constructor(name:string, description:string, category: number, bucketColor: any, maxAmountOfTasks: number,
        isActive: boolean, bucketTasks: any)
    {
        this.name = name;
        this.description = description;
        this.category = category;
        this.bucketColor = bucketColor;
        this.maxAmountOfTasks = maxAmountOfTasks;
        this.isActive = isActive;
        this.bucketTasks = bucketTasks;
    }
}