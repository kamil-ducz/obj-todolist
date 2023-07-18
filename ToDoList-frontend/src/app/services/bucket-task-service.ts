import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BucketTask } from "../models/bucket-task.model";
import { Observable } from "rxjs";

@Injectable ({
    providedIn: 'root'
})

export class BucketTaskService {
        
    constructor(
        private httpClient: HttpClient
    ) {}

    getBucketTasks(url): Observable<BucketTask[]> {
        return this.httpClient.get<BucketTask[]>(url);
    }

    getBucketTask(url): Observable<BucketTask> {
        return this.httpClient.get<BucketTask>(url);
    }

    postBucketTask(url, newBucketTask): Observable<BucketTask> {
        return this.httpClient.post<BucketTask>(url, newBucketTask);
    }

    putBucketTask(url, updatedBucketTask): Observable<BucketTask> {
        return this.httpClient.put<BucketTask>(url, updatedBucketTask);
    }

    deleteBucketTask(url): Observable<BucketTask> {
        return this.httpClient.delete<BucketTask>(url);
    }
}