import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { BucketCategory } from "../models/bucketCategory.model";

@Injectable ({
    providedIn: 'root'
})

export class DictionaryService {

    constructor(private httpClient: HttpClient) {}

    getBucketColorIdByName(url, bucketColorName: string): Observable<number> {
        return this.httpClient.get<number>(url, { params: { bucketColorName }});
    }
    
    getBucketColorNameById(url, bucketId: number): Observable<string> {
        return this.httpClient.get<string>(url, { params: { bucketId }});
    }

    getBucketCategoryIdByName(url, bucketCategoryName): Observable<number> {
    return this.httpClient.get<number>(url, { params: { bucketCategoryName }});
    }

    getBucketCategoryNameById(url): Observable<BucketCategory> {
        return this.httpClient.get<BucketCategory>(url);
      }
}