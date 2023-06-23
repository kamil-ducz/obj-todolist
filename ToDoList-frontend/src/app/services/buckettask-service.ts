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

    putBucketTask(id:number) {
        return this.httpClient.put('https://localhost:7247/api/BucketTask', null);
    }

    deleteBucketTask(id:number) {
        return this.httpClient.delete('https://localhost:7247/api/BucketTask');
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
    
}