import { Component, OnInit } from '@angular/core';
import { BucketService } from 'src/app/services/bucket-service';
import { Bucket } from 'src/app/models/bucket.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-bucket-new',
  templateUrl: './bucket-new.component.html',
  styleUrls: ['./bucket-new.component.css']
})
export class BucketNewComponent implements OnInit {

  constructor(private bucketService: BucketService) { }

  ngOnInit(): void {
  }

  newBucketFormGroup = new FormGroup({
    name: new FormControl('', [
      Validators.required,
      Validators.minLength(3),
    ]),
    description: new FormControl('', [
      Validators.maxLength(50),
    ]),
    category: new FormControl('', [
      Validators.required,      
    ]),
    bucketColor: new FormControl('', [
      Validators.required,
    ]),
    maxAmountOfTasks: new FormControl('3', [
      Validators.required,
      Validators.min(1),
      Validators.max(15),
    ]),
    isActive: new FormControl(true, [
      Validators.required,
    ])
  });

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

    switch(data.category) {
      case "Home": {
        data.category = 0;
        break;
      }
      case "Job": {
        data.category = 1;
        break;
      }
      case "Hobby": {
        data.category = 2;
        break;
      }
      default: {
        data.category = 0;
      }
    }

    console.log(data);

    this.bucketService.postBucket('https://localhost:7247/api/Bucket', data);
        this.toggleAdditionModal();
  }

  showModal = false;

  toggleAdditionModal() {
    this.showModal = !this.showModal;
  }

}
