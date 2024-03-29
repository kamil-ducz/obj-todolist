import { Component, OnInit } from '@angular/core';
import { BucketService } from 'src/app/services/bucket.service';
import { Bucket } from 'src/app/models/bucket.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-bucket-new',
  templateUrl: './bucket-new.component.html',
  styleUrls: ['./bucket-new.component.css']
})
export class BucketNewComponent implements OnInit {

  constructor(
    private bucketService: 
    BucketService, 
    private toastr: ToastrService
    ) { }

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
    bucketCategoryId: new FormControl('', [
      Validators.required,      
    ]),
    bucketColorId: new FormControl('', [
      Validators.required,
    ]),
    maxAmountOfTasks: new FormControl('1', [
      Validators.required,
      Validators.min(1),
      Validators.max(15),
    ]),
    isActive: new FormControl(true, [
      Validators.required,
    ])
  });

  onSubmitNewBucket(newBucket: Bucket) {
    this.bucketService.postBucket(newBucket).subscribe(
      (response: any) => {
        this.toastr.success(`Bucket ${newBucket.name} added successfully.`);
      }
    );
  }
}
