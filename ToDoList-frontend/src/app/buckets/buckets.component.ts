import { Component, OnInit } from '@angular/core';
import { BucketService } from '../services/bucket-service';

@Component({
  selector: 'app-buckets',
  templateUrl: './buckets.component.html',
  styleUrls: ['./buckets.component.css']
})
export class BucketsComponent implements OnInit {

  bucketsData: any;

  constructor(private bucketService: BucketService) { }

  ngOnInit() {
    this.bucketService.getBuckets().subscribe(
      (response: any) => {
        this.bucketsData = response;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }
}