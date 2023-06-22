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
        switch(this.currentBucket.bucketColor) {
          case 0: {
            this.currentBucket.bucketColor = "Brown";
            break;
          }
          case 1: {
            this.currentBucket.bucketColor = "Red";
            break;
          }
          case 2: {
            this.currentBucket.bucketColor = "Yellow";
            break;
          }
          case 3: {
            this.currentBucket.bucketColor = "Blue";
            break;
          }
          case 4: {
            this.currentBucket.bucketColor = "White";
            break;
          }
          case 5: {
            this.currentBucket.bucketColor = "Green";
            break;
          }
          default: {
            this.currentBucket.bucketColor = 3;
          }
        }
    
        switch(this.currentBucket.category) {
          case 0: {
            this.currentBucket.category = "Home";
            break;
          }
          case 1: {
            this.currentBucket.category = "Job";
            break;
          }
          case 2: {
            this.currentBucket.category = "Hobby";
            break;
          }
          default: {
            this.currentBucket.category = "Job";
          }
        }
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
    switch(this.editBucketFormGroup.value.bucketColor) {
      case "Brown": {
        this.editBucketFormGroup.value.bucketColor = 0;
        break;
      }
      case "Red": {
        this.editBucketFormGroup.value.bucketColor = 1;
        break;
      }
      case "Yellow": {
        this.editBucketFormGroup.value.bucketColor = 2;
        break;
      }
      case "Blue": {
        this.editBucketFormGroup.value.bucketColor = 3;
        break;
      }
      case "White": {
        this.editBucketFormGroup.value.bucketColor = 4;
        break;
      }
      case "Green": {
        this.editBucketFormGroup.value.bucketColor = 5;
        break;
      }
      default: {
        this.editBucketFormGroup.value.bucketColor = 3;
      }
    }

    switch(this.editBucketFormGroup.value.category) {
      case "Home": {
        this.editBucketFormGroup.value.category = 0;
        break;
      }
      case "Job": {
        this.editBucketFormGroup.value.category = 1;
        break;
      }
      case "Hobby": {
        this.editBucketFormGroup.value.category = 2;
        break;
      }
      default: {
        this.editBucketFormGroup.value.category = 0;
      }
    }

    this.currentBucket = this.editBucketFormGroup.value;

    this.bucketService.putBucket('https://localhost:7247/api/Bucket/'+this.id, this.currentBucket);
    this.toggleEditModal();
    
  }

  toggleEditModal() {
    this.showModal = !this.showModal;
  }

}
