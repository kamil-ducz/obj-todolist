import { Component, OnInit } from '@angular/core';
import { BucketService } from 'src/app/services/bucket-service';
import { Bucket } from 'src/app/models/bucket.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';

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

  onSubmitNewBucketTask(newBucketTask: Bucket) {
    newBucketTask.bucketColor = this.bucketService.mapBucketColorStringToEnum(newBucketTask.bucketColor);
    newBucketTask.category = this.bucketService.mapBucketColorStringToEnum(newBucketTask.category);

    this.bucketService.postBucket(environment.bucketEndpoint, newBucketTask).subscribe(
      (response: any) => {
        console.log(response);
      },
      (error: any) => {
        console.error(error);
      }
    );
    
    this.toggleAdditionModal();
  }

  showAddBucketModal = false;

  toggleAdditionModal() {
    this.showAddBucketModal = !this.showAddBucketModal;
  }
}