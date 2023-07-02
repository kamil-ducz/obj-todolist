import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Bucket } from "../models/bucket.model";
import { BucketTask } from "../models/bucketTask.model";
import { BucketColor } from "../models/bucketColor.model";

@Injectable ({
    providedIn: 'root'
})

export class BucketService {
        
    constructor(private httpClient: HttpClient) {}

    getBuckets(url): Observable<Bucket> {
        return this.httpClient.get<Bucket>(url);
    }

    getBucket(url): Observable<Bucket> {
        return this.httpClient.get<Bucket>(url);
    }

    getBucketTasks(url): Observable<BucketTask> {
      return this.httpClient.get<BucketTask>(url);
    }

    postBucket(url, newBucketData): Observable<Bucket> {
      return this.httpClient.post<Bucket>(url, newBucketData);
    }

    putBucket(url, data): Observable<any> {
        return this.httpClient.put<any>(url, data);
    }

    deleteBucket(url): Observable<Bucket> {
        return this.httpClient.delete<Bucket>(url);
    }
}