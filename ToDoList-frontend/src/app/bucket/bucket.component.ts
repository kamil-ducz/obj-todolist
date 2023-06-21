import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { BucketService } from '../services/bucket-service';
import { Bucket } from '../models/bucket.model';

@Component({
  selector: 'app-bucket',
  templateUrl: './bucket.component.html',
  styleUrls: ['./bucket.component.css']
})
export class BucketComponent implements OnInit {

  id: number;

  currentBucket: Bucket;

  constructor(private route: ActivatedRoute, private bucketService: BucketService) { }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
        console.log("this.id="+this.id);
      }
    )

    this.bucketService.getBucket(this.id).subscribe(
      (response: any) => {
        this.currentBucket = response;
      },
      (error: any) => {
        console.error(error);
      }
    );

    console.log("currentBucket: " + this.currentBucket);
  }

}
