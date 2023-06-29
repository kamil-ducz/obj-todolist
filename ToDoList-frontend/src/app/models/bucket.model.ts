export type Bucket = {
    id: number;
    name: string;
    description: string;
    bucketCategory: {
        id: number,
        name: string
    };
    bucketColor: {
        id: number,
        name: string
    };
    maxAmountOfTasks: number;
    isActive: boolean;
}