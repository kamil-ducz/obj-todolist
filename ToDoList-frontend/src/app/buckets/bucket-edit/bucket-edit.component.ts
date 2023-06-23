import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Bucket } from 'src/app/models/bucket.model';
import { BucketService } from 'src/app/services/bucket-service';

@Component({
  selector: 'app-bucket-edit',
  templateUrl: './bucket-edit.component.html',
  styleUrls: ['./bucket-edit.component.css']
})
export class BucketEditComponent implements OnInit {

  id: number;
  currentBucket: Bucket;
  editBucketFormGroup: FormGroup;
  showModal = false;

  constructor(private route: ActivatedRoute, private router: Router, private bucketService: BucketService) {}

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
      }
    )

    this.bucketService.getBucket(this.id).subscribe(
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

  onSubmit() {
    this.currentBucket = this.editBucketFormGroup.value;
    this.currentBucket.bucketColor = this.bucketService.mapBucketColorStringToEnum(this.editBucketFormGroup.value.bucketColor);
    this.currentBucket.category = this.bucketService.mapBucketCategoryStringToEnum(this.editBucketFormGroup.value.category);

    this.bucketService.putBucket('https://localhost:7247/api/Bucket/'+this.id, this.currentBucket);
    this.toggleEditModal();
  }

  toggleEditModal() {
    this.showModal = !this.showModal;
  }
}