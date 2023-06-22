export class BucketTask {
    public name: string;
    public description: string;
    public taskState: number;
    public taskPriority: number;

    constructor(name:string, description:string, taskState: number, taskPriority: number)
    {
        this.name = name;
        this.description = description;
        this.taskState  = taskState;
        this.taskPriority = taskPriority;
    }
}