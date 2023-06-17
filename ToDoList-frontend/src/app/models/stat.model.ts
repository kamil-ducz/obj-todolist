export class Stat {
    public percentOfTasksCompleted: number;
    public percentOfTasksToDo: number;
    public percentOfTasksInProgress: number;
    public percentOfTasksCancelled: number;

    constructor(percentOfTasksCompleted: number, percentOfTasksToDo: number, percentOfTasksInProgress: number, percentOfTasksCancelled: number)
    {
        this.percentOfTasksCompleted = percentOfTasksCompleted;
        this.percentOfTasksToDo = percentOfTasksToDo;
        this.percentOfTasksInProgress = percentOfTasksInProgress;
        this.percentOfTasksCancelled = percentOfTasksCancelled;
    }
}