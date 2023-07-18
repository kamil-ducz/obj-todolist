import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Bucket } from "../models/bucket.model";
import { BucketTask } from "../models/bucket-task.model";
import { BucketColor } from "../models/bucket-color.model";

@Injectable ({
    providedIn: 'root'
})

export class BucketService {
        
    constructor(
        private httpClient: HttpClient
    ) {}

    getBuckets(url): Observable<Bucket[]> {
        return this.httpClient.get<Bucket[]>(url);
    }

    getBucket(url): Observable<Bucket> {
        return this.httpClient.get<Bucket>(url);
    }

    getBucketTasks(url): Observable<BucketTask[]> {
      return this.httpClient.get<BucketTask[]>(url);
    }

    postBucket(url, newBucket): Observable<Bucket> {
      return this.httpClient.post<Bucket>(url, newBucket);
    }

    putBucket(url, updatedBucket): Observable<any> {
        return this.httpClient.put<any>(url, updatedBucket);
    }

    deleteBucket(url): Observable<Bucket> {
        return this.httpClient.delete<Bucket>(url);
    }
}