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
  constructor(
    private route: ActivatedRoute,
    private bucketService: BucketService,
    private dictionaryService: DictionaryService,
    private toastr: ToastrService
  ) {}

  currentBucketId: number;
  currentBucket: Bucket;
  bucketColors: BucketColor[];
  bucketCategories: BucketCategory[];
  editBucketFormGroup: FormGroup;

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.currentBucketId = +params['id'];
      this.loadCurrentBucket();
    });
  }

  async loadCurrentBucket() {
    try {
      const response = await this.bucketService.getBucket(environment.bucketEndpoint + this.currentBucketId).toPromise();
      this.currentBucket = response;
      await this.loadBucketsData();
      this.initializeEditForm();
    } catch (error) {
      this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name);
    }
  }

  async loadBucketCategories() {
    try {
      this.bucketCategories = await this.dictionaryService.getBucketCategories(environment.bucketCategoryEndpoint.concat("all")).toPromise();
    } catch (error) {
      this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name);
    }
  }

  async loadBucketColors() {
    try {
      this.bucketColors = await this.dictionaryService.getBucketColors(environment.bucketColorEndpoint.concat("all")).toPromise();
    } catch (error) {
      this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name);
    }
  }

  convertBucketColorIdToName(bucketColorId: number): void {
    this.dictionaryService.getBucketColorNameById(environment.bucketColorEndpoint + bucketColorId).subscribe(
      (response: any) => {
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.");
      }
    );
  }

  convertBucketCategoryIdToName(bucketCategoryId: number): void {
    this.dictionaryService.getBucketCategoryNameById(environment.bucketCategoryEndpoint + bucketCategoryId).subscribe(
      (response: any) => {
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.");
      }
    );
  }

  initializeEditForm() {
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

  loadBucketsData() {
    this.loadBucketCategories();
    this.loadBucketColors();
  }

  onSubmitEditForm(bucketFromEditForm: Bucket) {
    this.currentBucket = bucketFromEditForm;
    this.currentBucket.bucketCategory = null;
    this.currentBucket.bucketColor = null;
    const currentBucketCategory = this.editBucketFormGroup.get("bucketCategory").value;
    const currentBucketColor = this.editBucketFormGroup.get("bucketColor").value;
    const matchedCategory = this.bucketCategories.find(bcat => bcat.name.toLowerCase() === currentBucketCategory.toLowerCase());
    const matchedColor = this.bucketColors.find(bcol => bcol.name.toLowerCase() === currentBucketColor.toLowerCase());

    if (matchedCategory) {
      this.currentBucket.bucketCategoryId = matchedCategory.id;
    }

    if (matchedColor) {
      this.currentBucket.bucketColorId = matchedColor.id;
    }

    this.bucketService.putBucket(environment.bucketEndpoint + this.currentBucketId, this.currentBucket).subscribe(
      (response: Bucket) => {
        this.toastr.success("Bucket " + response.name + " edit successfull.");
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.")
      }
    );
  }
}
