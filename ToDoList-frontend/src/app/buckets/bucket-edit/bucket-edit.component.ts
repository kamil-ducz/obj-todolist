import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Bucket } from 'src/app/models/bucket.model';
import { BucketCategory } from 'src/app/models/bucketCategory.model';
import { BucketColor } from 'src/app/models/bucketColor.model';
import { BucketService } from 'src/app/services/bucket-service';
import { DictionaryService } from 'src/app/services/dictionary.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-bucket-edit',
  templateUrl: './bucket-edit.component.html',
  styleUrls: ['./bucket-edit.component.css']
})
export class BucketEditComponent implements OnInit {
  id: number;
  currentBucket: Bucket;
  currentBucketColorName: string;
  currentBucketCategoryName: string;
  editBucketFormGroup: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private bucketService: BucketService,
    private dictionaryService: DictionaryService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = +params['id'];

      this.bucketService.getBucket(environment.bucketEndpoint + this.id).subscribe(
        (response: any) => {
          this.currentBucket = response;
          this.initializeForm();
        },
        (error: any) => {
          this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name);
        }
      );
    });
  }

  convertBucketColorIdToName(bucketColorId: number): void {
    this.dictionaryService.getBucketColorNameById(environment.bucketColorEndpoint + bucketColorId).subscribe(
      (response: any) => {
        this.currentBucketColorName = response.name;
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.");
      }
    );
  }

  convertBucketCategoryIdToName(bucketCategoryId: number): void {
    this.dictionaryService.getBucketCategoryNameById(environment.bucketCategoryEndpoint + bucketCategoryId).subscribe(
      (response: any) => {
        this.currentBucketCategoryName = response.name;
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.");
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
      bucketCategory: new FormControl('', [
        Validators.required,      
      ]),
      bucketColor: new FormControl('', [
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

    this.loadBucketCategoryName(this.currentBucket.bucketCategoryId);
    this.loadBucketColorName(this.currentBucket.bucketColorId);
  }

  loadBucketCategoryName(bucketCategoryId: number) {
    this.dictionaryService.getBucketCategoryNameById(environment.bucketCategoryEndpoint + bucketCategoryId)
      .subscribe(
        (response: BucketCategory) => {
          this.editBucketFormGroup.patchValue({ bucketCategory: response.name });
        },
        (error: any) => {
          this.toastr.error("Failed to retrieve bucket category name. Check console logs and network tab to identify the issue.");
        }
      );
  }
  
  loadBucketColorName(bucketColorId: number) {
    this.dictionaryService.getBucketColorNameById(environment.bucketColorEndpoint + bucketColorId)
      .subscribe(
        (response: BucketColor) => {
          this.editBucketFormGroup.patchValue({ bucketColor: response.name });
        },
        (error: any) => {
          this.toastr.error("Failed to retrieve bucket color name. Check console logs and network tab to identify the issue.");
        }
      );
  }

  onSubmitEditForm(bucketFromEditForm: Bucket) {
    this.currentBucket = bucketFromEditForm;
    this.bucketService.putBucket(environment.bucketEndpoint + this.id, this.currentBucket).subscribe(
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
