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
      this.refreshComponent();
    });
  }

  async refreshComponent() {
    await this.loadCurrentBucket();
    await this.loadBucketCategories();
    await this.loadBucketColors();
    await this.initializeEditForm();
  }

  async loadCurrentBucket(): Promise<Bucket> {
    return new Promise<Bucket>((resolve) => {
      this.bucketService.getBucket(environment.bucketEndpoint + this.currentBucketId).subscribe(
        (response: Bucket) => {
          resolve(response);
        });
      });
  }

  loadBucketCategories() {
      this.dictionaryService.getBucketCategories(environment.bucketCategoryEndpoint).subscribe(
        (response: BucketCategory[]) => {
          this.bucketCategories = response;
          console.log("this.currentBucketCategories" + JSON.stringify(this.bucketCategories));
        },
        (error: any) => {
          this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name);
        }
      );
  }

  loadBucketColors() {
      this.dictionaryService.getBucketColors(environment.bucketColorEndpoint).subscribe(
        (response: BucketColor[]) => {
          this.bucketColors = response;
          console.log("this.currentBucketColors" + JSON.stringify(this.bucketColors));
        },
        (error: any) => {
          this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name);
        }
      );
  }

  async initializeEditForm() {
    this.currentBucket = await this.loadCurrentBucket();
    const bucketCategory = this.bucketCategories.find(bc => bc.id === this.currentBucket.bucketCategoryId).name;
    const bucketColor = this.bucketColors.find(bcol => bcol.id === this.currentBucket.bucketColorId).name;

    this.editBucketFormGroup = new FormGroup({
      name: new FormControl(this.currentBucket.name, [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new FormControl(this.currentBucket.description, [
        Validators.maxLength(50),
      ]),
      bucketCategory: new FormControl(bucketCategory, [
        Validators.required,      
      ]),
      bucketColor: new FormControl(bucketColor, [
        Validators.required,
      ]),
      maxAmountOfTasks: new FormControl(this.currentBucket.maxAmountOfTasks, [
        Validators.required,
        Validators.min(1),
        Validators.max(15),
      ]),
      isActive: new FormControl(this.currentBucket.isActive, [
        Validators.required,
      ])
    });
  }

  patchBucketEditForm() {
    this.editBucketFormGroup.patchValue({ name: this.currentBucket.name });
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
