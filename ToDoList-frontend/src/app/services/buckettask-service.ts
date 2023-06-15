import { HttpClient } from "@angular/common/http";

export class BucketTaskService {
        
    constructor(private httpClient: HttpClient) {}

    getBucketTasks(): void {
        this.httpClient.get('https://localhost:7247/api/BucketTask');
    }

    getBucketTask(id:number): void {
        this.httpClient.get('https://localhost:7247/api/BucketTask/{id}');
    }

    postBucketTask(id:number): void {
        this.httpClient.post('https://localhost:7247/api/BucketTask', null); //2nd argument to work out TODO
    }

    putBucketTask(id:number): void {
        this.httpClient.put('https://localhost:7247/api/BucketTask', null);
    }

    deleteBucketTask(id:number): void {
        this.httpClient.delete('https://localhost:7247/api/BucketTask');
    }
    
}