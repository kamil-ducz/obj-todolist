export class BucketTask {
    public name: string;
    public description: string;
    public taskState: any;
    public taskPriority: any;
    public bucketId: number;

    constructor(name:string, description:string, taskState: number, taskPriority: number, bucketId: number)
    {
        this.name = name;
        this.description = description;
        this.taskState  = taskState;
        this.taskPriority = taskPriority;
        this.bucketId = bucketId;
    }
}