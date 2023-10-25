import { Component, OnInit } from '@angular/core';
import { BucketService } from '../services/bucket.service';
import { PaginatedBucketResult } from '../models/paginated.bucket.result.model';
import { BucketPaginationService } from '../services/pagination.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  constructor(
    private bucketService: BucketService,
    private bucketPaginationService: BucketPaginationService,
    public router: Router
  ) {}

  paginatedBucketResult: PaginatedBucketResult;
  totalBuckets: number;
  totalPages: number;

  searchPhrase: string;
  currentPage: number = 1;
  itemsPerPage: number = 25;
  // Pages variable for pagination
  pages: number[];
  activePage: number = 1; // Initialize with page 1

  ngOnInit(): void {
    this.fetchPaginatedBuckets();
  }

  fetchPaginatedBuckets() {
    this.bucketService.getPaginatedBuckets(this.searchPhrase, this.currentPage, this.itemsPerPage).subscribe(
      (response: PaginatedBucketResult) => {
        this.paginatedBucketResult = response;
        this.totalBuckets = response.totalBuckets;
        this.totalPages = response.totalPages;
        this.pages = Array.from({ length: response.totalPages }, (_, index) => index + 1);
      }
    )
  }

  changeItemsPerPage() {
    this.bucketPaginationService.setItemsPerPage(this.itemsPerPage);
    this.changePage(1); // After selecting items per page always reset to page 1 to avoid missing buckets and keep it neat
  }

  changePage(page: number) {
    this.bucketPaginationService.setCurrentPage(page);
    this.activePage = page;
    this.fetchPaginatedBuckets();
  }
}
