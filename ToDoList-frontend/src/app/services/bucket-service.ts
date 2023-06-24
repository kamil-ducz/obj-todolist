import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Bucket } from "../models/bucket.model";
import { BucketTask } from "../models/buckettask.model";

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

    postBucket(url, data): Observable<Bucket> {
      return this.httpClient.post<Bucket>(url, data);
    }

    putBucket(url, data): Observable<any> {
        return this.httpClient.put<any>(url, data);
    }

    deleteBucket(url): Observable<Bucket> {
        return this.httpClient.delete<Bucket>(url);
    }

    mapBucketCategoryEnumToString(bucketCategory: number) {
        switch(bucketCategory) {
            case 0: {
                return "Home";
              }
              case 1: {
                return "Job";
              }
              case 2: {
                return "Hobby";
              }
              default: {
                return "Job";
              }
        }
    }

    mapBucketColorEnumToString(bucketColor: number) {
        switch(bucketColor) {
            case 0: {
                return "Brown";
              }
              case 1: {
                return "Red";
              }
              case 2: {
                return "Yellow";
              }
              case 3: {
                return "Blue";
              }
              case 4: {
                return "White";
              }
              case 5: {
                return "Green";
              }
              default: {
                return 3;
              }
        }
    }

    mapBucketCategoryStringToEnum(bucketCategory: string) {
        switch(bucketCategory) {
            case "Home": {
                return 0;
              }
              case "Job": {
                return 1;
              }
              case "Hobby": {
                return 2;
              }
              default: {
                return 0;
              }
        }
    }

    mapBucketColorStringToEnum(bucketColor: string) {
        switch(bucketColor) {
            case "Brown": {
                return 0;
              }
              case "Red": {
                return 1;
              }
              case "Yellow": {
                return 2;
              }
              case "Blue": {
                return 3;
              }
              case "White": {
                return 4;
              }
              case "Green": {
                return 5;
              }
              default: {
                return 3;
              }
        }
    }
}