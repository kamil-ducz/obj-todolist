export type BucketTask = {
    id: number;
    name: string;
    description: string;
    bucketTaskStateId: number;
    bucketTaskState: string;
    bucketTaskPriorityId: number;
    bucketTaskPriority: string;
    bucketId: number;
    assigneeId: number;
}