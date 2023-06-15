import { HttpClient } from "@angular/common/http";

export class BucketService {
        
    constructor(private httpClient: HttpClient) {}

    getBuckets(): void {
        this.httpClient.get('https://localhost:7247/api/Bucket');
    }

    getBucket(id:number): void {
        this.httpClient.get('https://localhost:7247/api/Bucket/{id}');
    }

    postBucket(id:number): void {
        this.httpClient.post('https://localhost:7247/api/Bucket', null); //2nd argument to work out TODO
    }

    putBucket(id:number): void {
        this.httpClient.put('https://localhost:7247/api/Bucket', null);
    }

    deleteBucket(id:number): void {
        this.httpClient.delete('https://localhost:7247/api/Bucket');
    }
    
}