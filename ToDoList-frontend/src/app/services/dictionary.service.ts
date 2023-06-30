import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { BucketCategory } from "../models/bucketCategory.model";
import { BucketColor } from "../models/bucketColor.model";

@Injectable ({
    providedIn: 'root'
})

export class DictionaryService {

    constructor(private httpClient: HttpClient) {}

    getBucketColorIdByName(url): Observable<BucketColor> {
        return this.httpClient.get<BucketColor>(url);
    }
    
    getBucketColorNameById(url): Observable<BucketColor> {
        return this.httpClient.get<BucketColor>(url);
    }

    getBucketCategoryIdByName(url): Observable<BucketCategory> {
    return this.httpClient.get<BucketCategory>(url);
    }

    getBucketCategoryNameById(url): Observable<BucketCategory> {
        return this.httpClient.get<BucketCategory>(url);
      }
}