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

// C# model
// public class StatsDTO
// {
//     public int Id { get; set; }
//     public decimal PercentOfTasksCompleted { get; set; }
//     public decimal PercentOfTasksToDo { get; set; }
//     public decimal PercentOfTasksInProgress { get; set; }
//     public decimal PercentOfTasksCancelled { get; set; }
// }