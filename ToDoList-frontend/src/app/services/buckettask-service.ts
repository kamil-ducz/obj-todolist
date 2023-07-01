import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BucketTask } from "../models/buckettask.model";
import { Observable } from "rxjs";

@Injectable ({
    providedIn: 'root'
})

export class BucketTaskService {
        
    constructor(private httpClient: HttpClient) {}

    getBucketTasks(url): Observable<BucketTask> {
        return this.httpClient.get<BucketTask>(url);
    }

    getBucketTask(url): Observable<BucketTask> {
        return this.httpClient.get<BucketTask>(url);
    }

    postBucketTask(url, data): Observable<BucketTask> {
        return this.httpClient.post<BucketTask>(url, data);
    }

    putBucketTask(url, data: BucketTask): Observable<BucketTask> {
        return this.httpClient.put<BucketTask>(url, data);
    }

    deleteBucketTask(url): Observable<BucketTask> {
        return this.httpClient.delete<BucketTask>(url);
    }
}