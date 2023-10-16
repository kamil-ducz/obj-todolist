import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Bucket } from "../models/bucket.model";
import { BucketTask } from "../models/bucket.task.model";

@Injectable ({
    providedIn: 'root'
})

export class BucketService {
        
    constructor(
        private httpClient: HttpClient
    ) {}

    getBuckets(): Observable<Bucket[]> {
        return this.httpClient.get<Bucket[]>('Bucket/all');
    }

    getPaginatedBuckets(searchPhrase: string, currentPage: number, itemsPerPage: number): Observable<Bucket[]> {
        const params = {
            searchPhrase: searchPhrase,
            currentPage: currentPage.toString(),
            itemsPerPage: itemsPerPage.toString()
        };
    
        return this.httpClient.get<Bucket[]>('Bucket/paginatedBuckets', { params: params });
    }

    getBucket(bucketId: number): Observable<Bucket> {
        return this.httpClient.get<Bucket>('Bucket/'+bucketId);
    }

    getBucketTasks(bucketId: number): Observable<BucketTask[]> {
      return this.httpClient.get<BucketTask[]>('Bucket/buckettask/'+bucketId);
    }

    postBucket(newBucket): Observable<Bucket> {
      return this.httpClient.post<Bucket>('Bucket/', newBucket);
    }

    putBucket(bucketId: number, updatedBucket): Observable<any> {
        return this.httpClient.put<any>('Bucket/'+bucketId, updatedBucket);
    }

    deleteBucket(bucketId: number): Observable<Bucket> {
        return this.httpClient.delete<Bucket>('Bucket/'+bucketId);
    }
}