import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
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

  constructor(private route: ActivatedRoute, private bucketService: BucketService) {}

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
      }
    )

    this.bucketService.getBucket(environment.bucketEndpoint+this.id).subscribe(
      (response: any) => {
        this.currentBucket = response;
        this.currentBucket.bucketColor = this.bucketService.mapBucketColorEnumToString(this.currentBucket.bucketColor);
        this.currentBucket.category = this.bucketService.mapBucketCategoryEnumToString(this.currentBucket.category);

        this.initializeForm();
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  initializeForm() {
    this.editBucketFormGroup = new FormGroup({
      name: new FormControl(this.currentBucket.name, [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new FormControl(this.currentBucket.description, [
        Validators.maxLength(50),
      ]),
      category: new FormControl(this.currentBucket.category, [
        Validators.required,      
      ]),
      bucketColor: new FormControl(this.currentBucket.bucketColor, [
        Validators.required,
      ]),
      maxAmountOfTasks: new FormControl(this.currentBucket.maxAmountOfTasks.toString(), [
        Validators.required,
        Validators.min(1),
        Validators.max(15),
      ]),
      isActive: new FormControl(this.currentBucket.isActive, [
        Validators.required,
      ])
    });
  }

  onSubmitEditForm(bucketFromEditForm: Bucket) {
    this.currentBucket = bucketFromEditForm;
    this.currentBucket.bucketColor = this.bucketService.mapBucketColorStringToEnum(bucketFromEditForm.bucketColor);
    this.currentBucket.category = this.bucketService.mapBucketCategoryStringToEnum(bucketFromEditForm.category);

    this.bucketService.putBucket(environment.bucketEndpoint+this.id, this.currentBucket).subscribe(
      (response: any) => {
        console.log(response);
      },
      (error: any) => {
        console.error(error);
      }
    );

    this.toggleEditModal();
  }

  showEditModal = false;

  toggleEditModal() {
    this.showEditModal = !this.showEditModal;
  }
}
