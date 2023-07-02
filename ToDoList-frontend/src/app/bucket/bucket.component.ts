import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { BucketService } from '../services/bucket-service';
import { Bucket } from '../models/bucket.model';
import { BucketTaskService } from '../services/buckettask-service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BucketTask } from '../models/bucketTask.model';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';
import { DictionaryService } from '../services/dictionary.service';
import { BucketTaskState } from '../models/bucketTaskState.model';
import { BucketTaskPriority } from '../models/bucketTaskPriority.model';

@Component({
  selector: 'app-bucket',
  templateUrl: './bucket.component.html',
  styleUrls: ['./bucket.component.css']
})
export class BucketComponent implements OnInit {

  constructor(
    private route: ActivatedRoute, 
    private router: Router, 
    private bucketService: BucketService, 
    private bucketTaskService: BucketTaskService, 
    private dictionaryService: DictionaryService, 
    private toastr: ToastrService
    ) { }

  currentBucketId: number;
  currentBucket: Bucket;
  currentBucketCategoryName: string;

  currentBucketBucketTasks: BucketTask[];
  currentBucketTask: BucketTask;
  bucketTaskStates: BucketTaskState[];
  bucketTaskPriorities: BucketTaskPriority[];
  bucketTasksToDo: BucketTask[];
  bucketTasksInProgress: BucketTask[];
  bucketTasksDone: BucketTask[];
  bucketTasksCancelled: BucketTask[];

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.currentBucketId = +params['id'];
      }
    );
    this.refreshCurrentBucketBucketTasksComponents();
  }
  
  refreshCurrentBucketBucketTasksComponents() {
    this.fetchCurrentBucket();
    this.fetchBucketTasks();
    this.fetchBucketTasksStates();
    this.fetchBucketTaskPriorities();
  }

  fetchCurrentBucket() {
    this.bucketService.getBucket(environment.bucketEndpoint+this.currentBucketId).subscribe(
      (response: Bucket) => {
        this.currentBucket = response;
        this.fetchCurrentBucketCategoryName(response.bucketCategoryId);
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  fetchCurrentBucketCategoryName(id: number) {
    this.dictionaryService.getBucketCategoryNameById(environment.bucketCategoryEndpoint+id).subscribe(
      (response: any) => {
        this.currentBucketCategoryName = response.name;
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.")
      }
    )
  }

  fetchBucketTasks() {
    this.bucketService.getBucketTasks(environment.buckeTasksForBucketEndpoint+this.currentBucketId).subscribe(
      (response: any) => {
        this.currentBucketBucketTasks = response;
        this.bucketTasksToDo = this.currentBucketBucketTasks.filter(element => element.bucketTaskStateId == 1);
        this.bucketTasksInProgress = this.currentBucketBucketTasks.filter(element => element.bucketTaskStateId == 2);
        this.bucketTasksDone = this.currentBucketBucketTasks.filter(element => element.bucketTaskStateId == 3);
        this.bucketTasksCancelled = this.currentBucketBucketTasks.filter(element => element.bucketTaskStateId == 4);
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  fetchBucketTasksStates() {
    this.dictionaryService.getBucketTaskStates(environment.bucketTaskStatesEndpoint).subscribe(
      (response: BucketTaskState[]) => {
        this.bucketTaskStates = response;
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name)
      }
    );
  }

  fetchBucketTaskPriorities() {
    this.dictionaryService.getBucketTaskPriorities(environment.bucketTaskPrioritiesEndoint).subscribe(
      (response: BucketTaskPriority[]) => {
        this.bucketTaskPriorities = response;
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name)
      }
    );
  }

  newBucketTaskToCreate: BucketTask;
  addNewBucketTaskFormGroup: FormGroup;
  editNewBucketTaskFormGroup: FormGroup;

  initializeNewBucketTaskForm() {
    this.addNewBucketTaskFormGroup = new FormGroup({
      name: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new FormControl('', [
        Validators.maxLength(50),
      ]),
      bucketTaskState: new FormControl('', [
        Validators.required,      
      ]),
      bucketTaskPriority: new FormControl('', [
        Validators.required,
      ]),
    });
  }

  initializeEditBucketTaskForm() {
    const bucketTaskState = this.bucketTaskStates.find(bts => bts.id === this.currentBucketTask.bucketTaskStateId).name;
    const bucketTaskPriority = this.bucketTaskPriorities.find(btps => btps.id === this.currentBucketTask.bucketTaskPriorityId).name;

    this.editNewBucketTaskFormGroup = new FormGroup({
      name: new FormControl(this.currentBucketTask.name, [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new FormControl(this.currentBucketTask.description, [
        Validators.maxLength(50),
      ]),
      bucketTaskState: new FormControl(bucketTaskState, [
        Validators.required,      
      ]),
      bucketTaskPriority: new FormControl(bucketTaskPriority, [
        Validators.required,
      ]),
    });
  }

  onSubmitNewBucketTask(newBucketTask: BucketTask) {
    this.refreshCurrentBucketBucketTasksComponents();
    this.currentBucketTask = newBucketTask;
    this.currentBucketTask.bucketTaskStateId = this.bucketTaskStates.find(bs => bs.name.toLowerCase().replace(' ', '') === this.currentBucketTask.bucketTaskState.toLowerCase().replace(' ', '')).id;
    this.currentBucketTask.bucketTaskPriorityId = this.bucketTaskPriorities.find(bp => bp.name.toLowerCase().replace(' ', '') === this.currentBucketTask.bucketTaskPriority.toLowerCase().replace(' ', '')).id;
    this.currentBucketTask.bucketTaskState = null;
    this.currentBucketTask.bucketTaskPriority = null;
    this.currentBucketTask.bucketsId = this.currentBucketId;
  
    if (this.currentBucketBucketTasks.length < this.currentBucket.maxAmountOfTasks)
    {
      this.bucketTaskService.postBucketTask(environment.bucketTaskEndpoint, this.currentBucketTask).subscribe(
        (response) => {
          this.toastr.success("Bucket task " + this.currentBucketTask.name + " created successfully.");
        },
        (error: any) => {
          this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name)
        }
      );
    }
    else 
    {
      this.popNewBucketTaskMaxAmountOfTasksReachedWarning();
      return null;
    }
  }

  onSubmitEditBucketTask(newBucketTask: BucketTask) {
    newBucketTask = this.editNewBucketTaskFormGroup.value;
    newBucketTask.bucketsId = this.currentBucketId;
    this.bucketTaskService.putBucketTask(environment.bucketTaskEndpoint+this.currentBucketTask.id, newBucketTask).subscribe(
      (response: any) => {
        console.log(response);
      },
      (error: any) => {
        console.error(error);
      }
    );

    this.popEditBucketTaskConfirmationModal();
  }

  removeBucket(id: any) {
    this.bucketService.deleteBucket(environment.bucketEndpoint+id).subscribe(
        (response: any) => {
          this.toastr.success("Bucket " +this.currentBucket.name + " deleted successfully.");
          this.router.navigate(['/buckets']);
        },
        (error: any) => {
          this.toastr.error("Request failed. Check console logs and network tab to identify the issue.")
        }
    );
  }

  removeBucketTask(bucketTaskId: number) {
    this.bucketTaskService.deleteBucketTask(environment.bucketTaskEndpoint+bucketTaskId).subscribe(
      (response: any) => {
        this.fetchBucketTasks();
        this.exitDeleteBucketTaskConfirmationModal();
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.")
      }
    );
  }

  showModal = false;

  toggleDeleteModal(i: number, e: Event) {
    this.showModal = !this.showModal;
    event.stopPropagation();
  }

  showNewBucketTaskForm = false;
  showEditBucketTaskForm = false;
  bucketTaskEditConfirmationModal = false;
  bucketTaskDeleteConfirmationModal = false;

  popupNewBucketTaskForm() {
    this.showNewBucketTaskForm = !this.showNewBucketTaskForm;
    this.initializeNewBucketTaskForm();
  }

  exitNewBucketTaskForm() {
    this.showNewBucketTaskForm = !this.showNewBucketTaskForm;
    this.refreshCurrentBucketBucketTasksComponents();
  }

  exitNewBucketTaskConfirmationModal() {
    this.exitNewBucketTaskForm();
  }

  popEditBucketTaskForm(bucketTaskId: number) {
    this.showEditBucketTaskForm = !this.showEditBucketTaskForm;
    this.currentBucketTask = this.currentBucketBucketTasks.find(element => element.id == bucketTaskId);
    this.initializeEditBucketTaskForm();
  }

  exitEditBucketTaskForm() {
    this.showEditBucketTaskForm = false;
    this.refreshCurrentBucketBucketTasksComponents();
  }

  popEditBucketTaskConfirmationModal() {
    this.bucketTaskEditConfirmationModal = !this.bucketTaskEditConfirmationModal;
  }

  exitEditBucketTaskConfirmationModal() {
    this.bucketTaskEditConfirmationModal = false;
    this.exitEditBucketTaskForm();
  }

  popDeleteBucketTaskConfirmationModal() {    
    this.bucketTaskDeleteConfirmationModal = !this.bucketTaskDeleteConfirmationModal;
  }

  exitDeleteBucketTaskConfirmationModal() {
    this.bucketTaskDeleteConfirmationModal = false;
    this.exitEditBucketTaskConfirmationModal()
  }

  MaxAmountOfTasksReachedWarningModal = false;

  popNewBucketTaskMaxAmountOfTasksReachedWarning() {
    this.MaxAmountOfTasksReachedWarningModal = true;
  }

  exitNewBucketTaskMaxAmountOfTasksReachedWarning() {
    this.MaxAmountOfTasksReachedWarningModal = false;
  }
}
