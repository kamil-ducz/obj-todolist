import { Component, OnInit } from '@angular/core';
import { BucketService } from 'src/app/services/bucket-service';
import { Bucket } from 'src/app/models/bucket.model';
import { UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-bucket-new',
  templateUrl: './bucket-new.component.html',
  styleUrls: ['./bucket-new.component.css']
})
export class BucketNewComponent implements OnInit {

  constructor(private bucketService: BucketService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  newBucketFormGroup = new UntypedFormGroup({
    name: new UntypedFormControl('', [
      Validators.required,
      Validators.minLength(3),
    ]),
    description: new UntypedFormControl('', [
      Validators.maxLength(50),
    ]),
    category: new UntypedFormControl('', [
      Validators.required,      
    ]),
    bucketColor: new UntypedFormControl('', [
      Validators.required,
    ]),
    maxAmountOfTasks: new UntypedFormControl('3', [
      Validators.required,
      Validators.min(1),
      Validators.max(15),
    ]),
    isActive: new UntypedFormControl(true, [
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
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.")
      }
    );
    
    this.toggleAdditionModal();
  }

  showAddBucketModal = false;

  toggleAdditionModal() {
    this.showAddBucketModal = !this.showAddBucketModal;
  }
}