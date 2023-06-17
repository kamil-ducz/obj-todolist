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

    postBucket(id:number) {
        return this.httpClient.post('https://localhost:7247/api/Bucket', null); //2nd argument to work out TODO
    }

    putBucket(id:number) {
        return this.httpClient.put('https://localhost:7247/api/Bucket', null);
    }

    deleteBucket(id:number) {
        return this.httpClient.delete('https://localhost:7247/api/Bucket');
    }
    
}