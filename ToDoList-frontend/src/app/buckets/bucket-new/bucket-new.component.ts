import { Component, OnInit } from '@angular/core';
import { BucketService } from 'src/app/services/bucket-service';
import { Bucket } from 'src/app/models/bucket.model';

@Component({
  selector: 'app-bucket-new',
  templateUrl: './bucket-new.component.html',
  styleUrls: ['./bucket-new.component.css']
})
export class BucketNewComponent implements OnInit {

  constructor(private bucketService: BucketService) { }

  ngOnInit(): void {
  }

  onSubmit(data: Bucket) {
    switch(data.bucketColor) {
      case "Brown": {
        data.bucketColor = 0;
        break;
      }
      case "Red": {
        data.bucketColor = 1;
        break;
      }
      case "Yellow": {
        data.bucketColor = 2;
        break;
      }
      case "Blue": {
        data.bucketColor = 3;
        break;
      }
      case "White": {
        data.bucketColor = 4;
        break;
      }
      case "Green": {
        data.bucketColor = 5;
        break;
      }
      default: {
        data.bucketColor = 3;
      }
    }
    console.log(data);
    this.bucketService.postBucket('https://localhost:7247/api/Bucket', data);
  }

}
