import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BucketTask } from "../models/bucket.task.model";
import { Observable } from "rxjs";

@Injectable ({
    providedIn: 'root'
})

export class BucketTaskService {
        
    constructor(
        private httpClient: HttpClient
    ) {}

    getBucketTasks(): Observable<BucketTask[]> {
        return this.httpClient.get<BucketTask[]>('BucketTask/');
    }

    getBucketTask(bucketId: number): Observable<BucketTask> {
        return this.httpClient.get<BucketTask>('BucketTask/'+bucketId);
    }

    postBucketTask(newBucketTask): Observable<BucketTask> {
        return this.httpClient.post<BucketTask>('BucketTask/', newBucketTask);
    }

    putBucketTask(bucketTaskId: number, updatedBucketTask): Observable<BucketTask> {
        return this.httpClient.put<BucketTask>('BucketTask/'+bucketTaskId, updatedBucketTask);
    }

    deleteBucketTask(bucketTaskId: number): Observable<BucketTask> {
        return this.httpClient.delete<BucketTask>('BucketTask/'+bucketTaskId);
    }
}