import { Component, OnInit } from '@angular/core';
import { FormGroup, UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Bucket } from 'src/app/models/bucket.model';
import { BucketService } from 'src/app/services/bucket-service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-bucket-edit',
  templateUrl: './bucket-edit.component.html',
  styleUrls: ['./bucket-edit.component.css']
})
export class BucketEditComponent implements OnInit {

  id: number;
  currentBucket: Bucket;
  editBucketFormGroup: FormGroup;

  constructor(private route: ActivatedRoute, private bucketService: BucketService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
      }
    )

    this.bucketService.getBucket(environment.bucketEndpoint+this.id).subscribe(
      (response: any) => {
        this.currentBucket = response;        
        this.initializeForm();
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.")
      }
    );
  }

  initializeForm() {
    this.editBucketFormGroup = new UntypedFormGroup({
      name: new UntypedFormControl(this.currentBucket.name, [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new UntypedFormControl(this.currentBucket.description, [
        Validators.maxLength(50),
      ]),
      category: new UntypedFormControl(this.currentBucket.bucketCategoryId, [
        Validators.required,      
      ]),
      bucketColor: new UntypedFormControl(this.currentBucket.bucketColorId, [
        Validators.required,
      ]),
      maxAmountOfTasks: new UntypedFormControl(this.currentBucket.maxAmountOfTasks.toString(), [
        Validators.required,
        Validators.min(1),
        Validators.max(15),
      ]),
      isActive: new UntypedFormControl(this.currentBucket.isActive, [
        Validators.required,
      ])
    });
  }

  onSubmitEditForm(bucketFromEditForm: Bucket) {
    this.currentBucket = bucketFromEditForm;
    this.bucketService.putBucket(environment.bucketEndpoint+this.id, this.currentBucket).subscribe(
      (response: any) => {
        console.log(response);
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.")
      }
    );

    this.toggleEditModal();
  }

  showEditModal = false;

  toggleEditModal() {
    this.showEditModal = !this.showEditModal;
  }
}
