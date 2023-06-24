import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { BucketService } from '../services/bucket-service';
import { Bucket } from '../models/bucket.model';
import { BucketTaskService } from '../services/buckettask-service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BucketTask } from '../models/buckettask.model';

@Component({
  selector: 'app-bucket',
  templateUrl: './bucket.component.html',
  styleUrls: ['./bucket.component.css']
})
export class BucketComponent implements OnInit {

  id: number;

  currentBucket: Bucket;

  currentBucketBucketTasks: any;
  currentBucketTask: any;
  bucketTasksToDo: any;
  bucketTasksInProgress: any;
  bucketTasksDone: any;
  bucketTasksCancelled: any;

  newBucketTaskToCreate: BucketTask;
  addNewBucketTaskFormGroup: FormGroup;
  editNewBucketTaskFormGroup: FormGroup;
  
  constructor(private route: ActivatedRoute, private router: Router, 
              private bucketService: BucketService, private bucketTaskService: BucketTaskService) { }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
      }
    )

    this.bucketService.getBucket(this.id).subscribe(
      (response: any) => {
        this.currentBucket = response;
        this.currentBucket.category = this.bucketService.mapBucketCategoryEnumToString(this.currentBucket.category);
      },
      (error: any) => {
        console.error(error);
      }
    );

    this.fetchBucketTasks();
  }

  fetchBucketTasks() {
    this.bucketService.getBucketTasks(this.id).subscribe(
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

  
  initializeNewBucketTaskForm() {
    this.addNewBucketTaskFormGroup = new FormGroup({
      name: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new FormControl('', [
        Validators.maxLength(50),
      ]),
      state: new FormControl('', [
        Validators.required,      
      ]),
      priority: new FormControl('', [
        Validators.required,
      ]),
    });
  }

  initializeEditBucketTaskForm() {
    this.editNewBucketTaskFormGroup = new FormGroup({
      name: new FormControl(this.currentBucketTask.name, [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new FormControl(this.currentBucketTask.description, [
        Validators.maxLength(50),
      ]),
      state: new FormControl(this.currentBucketTask.taskState, [
        Validators.required,      
      ]),
      priority: new FormControl(this.currentBucketTask.taskPriority, [
        Validators.required,
      ]),
    });
  }

  onSubmitNewBucketTask(data: BucketTask) {
    data.bucketId = this.id;
    data.taskState = this.bucketTaskService.mapBucketTaskStateStringToEnum(this.addNewBucketTaskFormGroup.value.state);
    data.taskPriority = this.bucketTaskService.mapBucketTaskPriorityStringToEnum(this.addNewBucketTaskFormGroup.value.priority);
    this.bucketTaskService.postBucketTask('https://localhost:7247/api/BucketTask/', data);

    this.popNewBucketTaskConfirmationModal();
  }

  onSubmitEditBucketTask(data: BucketTask) {
    data = this.editNewBucketTaskFormGroup.value;
    data.taskState = this.bucketTaskService.mapBucketTaskStateStringToEnum(this.editNewBucketTaskFormGroup.value.state);
    data.taskPriority = this.bucketTaskService.mapBucketTaskPriorityStringToEnum(this.editNewBucketTaskFormGroup.value.priority);
    this.bucketTaskService.putBucketTask('https://localhost:7247/api/BucketTask/'+this.currentBucketTask.id, data);

    this.popEditBucketTaskConfirmationModal();
  }

  removeBucket(id: any) {
    this.bucketService.deleteBucket(id).subscribe(
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
    this.bucketTaskService.deleteBucketTask('https://localhost:7247/api/BucketTask/'+bucketTaskId).subscribe(
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
    this.ngOnInit();
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
    this.ngOnInit();
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
}
