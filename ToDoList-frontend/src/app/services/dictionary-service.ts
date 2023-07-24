import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { BucketCategory } from "../models/bucket-category.model";
import { BucketColor } from "../models/bucket-color.model";
import { BucketTaskState } from "../models/bucket-task-state.model";
import { BucketTaskPriority } from "../models/bucket-task-priority.model";

@Injectable ({
    providedIn: 'root'
})

export class DictionaryService {

    constructor(
        private httpClient: HttpClient
    ) {}

    getBucketColors(): Observable<BucketColor[]> {
        return this.httpClient.get<BucketColor[]>('Dictionary/bucketColors/');
    }

    getBucketCategories(): Observable<BucketCategory[]> {
        return this.httpClient.get<BucketCategory[]>('Dictionary/bucketCategories/');
    }

    getBucketTaskStates(): Observable<BucketTaskState[]> {
        return this.httpClient.get<BucketTaskState[]>('Dictionary/bucketTaskStates/');
    }

    getBucketTaskPriorities(): Observable<BucketTaskPriority[]> {
        return this.httpClient.get<BucketTaskPriority[]>('Dictionary/bucketTaskPriorities/');
    }
}