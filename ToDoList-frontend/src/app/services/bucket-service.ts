import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Bucket } from "../models/bucket.model";

@Injectable ({
    providedIn: 'root'
})

export class BucketService {
        
    constructor(private httpClient: HttpClient) {}

    getBuckets(): Observable<Bucket> {
        return this.httpClient.get<Bucket>('https://localhost:7247/api/Bucket');
    }

    getBucket(id:number) {
        return this.httpClient.get('https://localhost:7247/api/Bucket/{id}');
    }

    postBucket(url, data) {
        this.httpClient.post(url, data).subscribe(
            (result) => {
                console.log(result);
            },
            (error: any) => {
                console.error(error);
            }
        );
    }

    putBucket(id:number) {
        return this.httpClient.put('https://localhost:7247/api/Bucket', null);
    }

    deleteBucket(id:any): Observable<Bucket> {
        return this.httpClient.delete<Bucket>('https://localhost:7247/api/Bucket/'+id);
    }
    
}