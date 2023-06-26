import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { BucketService } from '../services/bucket-service';
import { Bucket } from '../models/bucket.model';
import { BucketTaskService } from '../services/buckettask-service';
import { FormGroup, UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { BucketTask } from '../models/buckettask.model';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-bucket',
  templateUrl: './bucket.component.html',
  styleUrls: ['./bucket.component.css']
})
export class BucketComponent implements OnInit {

  id: number;

  currentBucket: Bucket;

  fetchCurrentBucket() {
    this.bucketService.getBucket(environment.bucketEndpoint+this.id).subscribe(
      (response: any) => {
        this.currentBucket = response;
        this.currentBucket.category = this.bucketService.mapBucketCategoryEnumToString(this.currentBucket.category);
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  currentBucketBucketTasks: BucketTask[];
  currentBucketTask: BucketTask;
  bucketTasksToDo: BucketTask[];
  bucketTasksInProgress: BucketTask[];
  bucketTasksDone: BucketTask[];
  bucketTasksCancelled: BucketTask[];

  fetchBucketTasks() {
    this.bucketService.getBucketTasks(environment.buckeTasksForBucketEndpoint+this.id).subscribe(
      (response: any) => {
        this.currentBucketBucketTasks = response;
        this.bucketTasksToDo = this.currentBucketBucketTasks.filter(element => element.taskState == 0);
        this.bucketTasksInProgress = this.currentBucketBucketTasks.filter(element => element.taskState == 1);
        this.bucketTasksDone = this.currentBucketBucketTasks.filter(element => element.taskState == 2);
        this.bucketTasksCancelled = this.currentBucketBucketTasks.filter(element => element.taskState == 3);
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  newBucketTaskToCreate: BucketTask;
  addNewBucketTaskFormGroup: FormGroup;
  editNewBucketTaskFormGroup: FormGroup;
  
  constructor(private route: ActivatedRoute, private router: Router, 
              private bucketService: BucketService, private bucketTaskService: BucketTaskService) { }

  refreshCurrentBucketBucketTasksComponents() {
    this.fetchCurrentBucket();
    this.fetchBucketTasks();
  }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
      }
    );
    this.refreshCurrentBucketBucketTasksComponents();
  }

  initializeNewBucketTaskForm() {
    this.addNewBucketTaskFormGroup = new UntypedFormGroup({
      name: new UntypedFormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new UntypedFormControl('', [
        Validators.maxLength(50),
      ]),
      state: new UntypedFormControl('', [
        Validators.required,      
      ]),
      priority: new UntypedFormControl('', [
        Validators.required,
      ]),
    });
  }

  initializeEditBucketTaskForm() {
    this.editNewBucketTaskFormGroup = new UntypedFormGroup({
      name: new UntypedFormControl(this.currentBucketTask.name, [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new UntypedFormControl(this.currentBucketTask.description, [
        Validators.maxLength(50),
      ]),
      state: new UntypedFormControl(this.currentBucketTask.taskState, [
        Validators.required,      
      ]),
      priority: new UntypedFormControl(this.currentBucketTask.taskPriority, [
        Validators.required,
      ]),
    });
  }

  onSubmitNewBucketTask(newBucketTask: BucketTask) {
    newBucketTask.bucketId = this.id;
    newBucketTask.taskState = this.bucketTaskService.mapBucketTaskStateStringToEnum(this.addNewBucketTaskFormGroup.value.state);
    newBucketTask.taskPriority = this.bucketTaskService.mapBucketTaskPriorityStringToEnum(this.addNewBucketTaskFormGroup.value.priority);
    if (this.currentBucketBucketTasks.length < this.currentBucket.maxAmountOfTasks)
    {
      this.bucketTaskService.postBucketTask(environment.bucketTaskEndpoint, newBucketTask).subscribe(
        (response) => {
          console.log(response);
        },
        (error: any) => {
          console.error(error);
        }
      );
  
      this.popNewBucketTaskConfirmationModal();
    }
    else 
    {
      this.popNewBucketTaskMaxAmountOfTasksReachedWarning();
      return null;
    }
  }

  onSubmitEditBucketTask(newBucketTask: BucketTask) {
    newBucketTask = this.editNewBucketTaskFormGroup.value;
    newBucketTask.bucketId = this.id;
    newBucketTask.taskState = this.bucketTaskService.mapBucketTaskStateStringToEnum(this.editNewBucketTaskFormGroup.value.state);
    newBucketTask.taskPriority = this.bucketTaskService.mapBucketTaskPriorityStringToEnum(this.editNewBucketTaskFormGroup.value.priority);
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
          this.exitDeleteModal();
          this.router.navigate(['/buckets']);
        },
        (error: any) => {
          console.error(error);
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
        console.error(error);
      }
    );
  }

  showModal = false;

  toggleDeleteModal(i: number, e: Event) {
    this.showModal = !this.showModal;
    event.stopPropagation();
  }

  exitDeleteModal() {
    this.showModal = !this.showModal;
  }

  showNewBucketTaskForm = false;
  showEditBucketTaskForm = false;
  bucketTaskNewConfirmationModal = false;
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

  popNewBucketTaskConfirmationModal() {
    this.bucketTaskNewConfirmationModal = !this.bucketTaskNewConfirmationModal;
  }

  exitNewBucketTaskConfirmationModal() {
    this.bucketTaskNewConfirmationModal = !this.bucketTaskNewConfirmationModal;
    this.exitNewBucketTaskForm();
  }

  popEditBucketTaskForm(bucketTaskId: number) {
    this.showEditBucketTaskForm = !this.showEditBucketTaskForm;
    this.currentBucketTask = this.currentBucketBucketTasks.find(element => element.id == bucketTaskId);
    this.currentBucketTask.taskState = this.bucketTaskService.mapBucketTaskStateEnumToString(this.currentBucketTask.taskState);
    this.currentBucketTask.taskPriority = this.bucketTaskService.mapBucketTaskPriorityEnumToString(this.currentBucketTask.taskPriority);
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
