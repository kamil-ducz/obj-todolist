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

    mapBucketTaskStateStringToEnum(bucketTaskState: string) {
        switch(bucketTaskState) {
            case "To do": {
                return 0;
            }
            case "In progress": {
                return 1;
            }
            case "Done": {
                return 2;
            }
            case "Cancelled": {
                return 3;
            }
            default: {
                return 3;
            }
        }
    }

    mapBucketTaskPriorityStringToEnum(bucketTaskPriority) {
        switch(bucketTaskPriority) {
            case "High": {
                return 0;
            }
            case "Medium": {
                return 1;
            }
            case "Low": {
                return 2;
            }
            default: {
                return 2;
            }
        }
    }

    mapBucketTaskStateEnumToString(bucketTaskState: number) {
        switch(bucketTaskState) {
            case 0: {
                return "To do";
            }
            case 1: {
                return "In progress";
            }
            case 2: {
                return "Done";
            }
            case 3: {
                return "Cancelled";
            }
            default: {
                return "Cancelled";
            }
        }
    }

    mapBucketTaskPriorityEnumToString(bucketTaskPriority) {
        switch(bucketTaskPriority) {
            case 0: {
                return "High";
            }
            case 1: {
                return "Medium";
            }
            case 2: {
                return "Low";
            }
            default: {
                return "Low";
            }
        }
    }
}