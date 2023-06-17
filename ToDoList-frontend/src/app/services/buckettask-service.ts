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

    postBucketTask(id:number) {
        return this.httpClient.post('https://localhost:7247/api/BucketTask', null); //2nd argument to work out TODO
    }

    putBucketTask(id:number) {
        return this.httpClient.put('https://localhost:7247/api/BucketTask', null);
    }

    deleteBucketTask(id:number) {
        return this.httpClient.delete('https://localhost:7247/api/BucketTask');
    }
    
}