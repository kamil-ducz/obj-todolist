import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BucketTask } from "../models/buckettask.model";
import { Observable } from "rxjs";

@Injectable ({
    providedIn: 'root'
})

export class BucketTaskService {
        
    constructor(private httpClient: HttpClient) {}

    getBucketTasks(): Observable<BucketTask> {
        return this.httpClient.get<BucketTask>('https://localhost:7247/api/BucketTask');
    }

    getBucketTask(id:number) {
        return this.httpClient.get('https://localhost:7247/api/BucketTask/{id}');
    }

    postBucketTask(url, data) {
        return this.httpClient.post(url, data).subscribe(
            (response: any) => {
                console.log(response);
            },
            (error: any) => {
                console.error(error);
            }
        );
    }

    putBucketTask(url, data: BucketTask) {
        return this.httpClient.put(url, data).subscribe(
            (response: any) => {
                console.log(response);
            },
            (error: any) => {
                console.error(error);
            }
        );
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