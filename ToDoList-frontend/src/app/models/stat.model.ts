export class Stat {
    public Completed: number;
    public ToDo: number;
    public InProgress: number;
    public Cancelled: number;

    constructor(Completed: number, ToDo: number, InProgress: number, Cancelled: number)
    {
        this.Completed = Completed;
        this.ToDo = ToDo;
        this.InProgress = InProgress;
        this.Cancelled = Cancelled;
    }
}