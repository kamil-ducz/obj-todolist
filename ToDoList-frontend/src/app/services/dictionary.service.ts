import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { BucketCategory } from "../models/bucketCategory.model";
import { BucketColor } from "../models/bucketColor.model";
import { BucketTaskState } from "../models/bucketTaskState.model";
import { BucketTaskPriority } from "../models/bucketTaskPriority.model";

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

    getBucketColorIdByName(url): Observable<BucketColor> {
        return this.httpClient.get<BucketColor>(url);
    }
    
    getBucketColorNameById(url): Observable<BucketColor> {
        return this.httpClient.get<BucketColor>(url);
    }

    getBucketCategories(url): Observable<BucketCategory[]> {
        return this.httpClient.get<BucketCategory[]>(url);
    }

    getBucketCategoryIdByName(url): Observable<BucketCategory> {
        return this.httpClient.get<BucketCategory>(url);
    }

    getBucketCategoryNameById(url): Observable<BucketCategory> {
        return this.httpClient.get<BucketCategory>(url);
      }

    getBucketTaskStates(url): Observable<BucketTaskState[]> {
        return this.httpClient.get<BucketTaskState[]>(url);
    }

    getBucketTaskPriorities(url): Observable<BucketTaskPriority[]> {
        return this.httpClient.get<BucketTaskPriority[]>(url);
    }
}