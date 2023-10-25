import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { PaginatedBucketResult } from "../models/paginated.bucket.result.model";

@Injectable({
  providedIn: 'root'
})
export class BucketPaginationService {
  constructor() {}

  private currentPageSubject: BehaviorSubject<number> = new BehaviorSubject<number>(1);
  public currentPage$: Observable<number> = this.currentPageSubject.asObservable();

  private itemsPerPageSubject: BehaviorSubject<number> = new BehaviorSubject<number>(25);
  public itemsPerPage$: Observable<number> = this.itemsPerPageSubject.asObservable();

  setCurrentPage(page: number) {
    this.currentPageSubject.next(page);
  }

  setItemsPerPage(itemsPerPage: number) {
    this.itemsPerPageSubject.next(itemsPerPage);
  }
}