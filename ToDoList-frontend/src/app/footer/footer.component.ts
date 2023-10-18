import { Component, OnInit } from '@angular/core';
import { BucketService } from '../services/bucket.service';
import { PaginatedBucketResult } from '../models/paginated.bucket.result.model';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  constructor(
    private bucketService: BucketService,
  ) {}

  paginatedBucketResult: PaginatedBucketResult;

  searchPhrase: string;
  currentPage: number = 1;
  itemsPerPage: number = 15;
  totalPages: number;
  // Pages variable for pagination
  pages: number[];

  ngOnInit(): void {
    this.fetchPaginatedBuckets();
  }

  fetchPaginatedBuckets() {
    this.bucketService.getPaginatedBuckets(this.searchPhrase, this.currentPage, this.itemsPerPage).subscribe(
      (response: PaginatedBucketResult) => {
        this.paginatedBucketResult = response;
        this.totalPages = response.totalPages;
        this.pages = Array.from({ length: this.totalPages }, (_, index) => index + 1);
        console.log("response in JSON = " + JSON.stringify(response));
        console.log("this.paginatedBucketResult = " + JSON.stringify(this.paginatedBucketResult));
      }
    )
  }

  goToPage(page: number) {
    this.currentPage = page;
    this.fetchPaginatedBuckets();

  }

  changeItemsPerPage() {

  }

}
