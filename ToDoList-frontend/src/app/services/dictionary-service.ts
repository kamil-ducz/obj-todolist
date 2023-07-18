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

    getBucketColors(url): Observable<BucketColor[]> {
        return this.httpClient.get<BucketColor[]>(url);
    }

    getBucketCategories(url): Observable<BucketCategory[]> {
        return this.httpClient.get<BucketCategory[]>(url);
    }

    getBucketTaskStates(url): Observable<BucketTaskState[]> {
        return this.httpClient.get<BucketTaskState[]>(url);
    }

    getBucketTaskPriorities(url): Observable<BucketTaskPriority[]> {
        return this.httpClient.get<BucketTaskPriority[]>(url);
    }
}