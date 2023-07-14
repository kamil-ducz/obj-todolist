import { Component, OnInit } from '@angular/core';
import { BucketService } from '../services/bucket-service';
import { BucketTaskService } from '../services/buckettask-service';
import { environment } from 'src/environments/environment';
import { Bucket } from '../models/bucket.model';
import { BucketTask } from '../models/bucket-task.model';
import { ToastrService } from 'ngx-toastr';
import { BucketTaskState } from '../models/bucket-task-state.model';
import { BucketTaskPriority } from '../models/bucket-task-priority.model';
import { DictionaryService } from '../services/dictionary.service';

@Component({
  selector: 'app-buckets',
  templateUrl: './buckets.component.html',
  styleUrls: ['./buckets.component.css']
})
export class BucketsComponent implements OnInit {
  constructor(
    private bucketService: BucketService, 
    private bucketTaskService: BucketTaskService, 
    private dictionaryService: DictionaryService, 
    private toastr: ToastrService
    ) { }

  buckets: Bucket[];
  bucketTasks: BucketTask[];
  bucketTaskStates: BucketTaskState[];
  bucketTaskPriorities: BucketTaskPriority[];
  bucketTasksToDo: BucketTask[];
  bucketTasksInProgress: BucketTask[];
  bucketTasksDone: BucketTask[];
  bucketTasksCancelled: BucketTask[];

  ngOnInit() {
    this.refreshBucketAndBucketsComponents();
  }

  refreshBucketAndBucketsComponents() {
    this.fetchBuckets();
    this.fetchBucketTasks();
    this.fetchBucketTasksStates();
    this.fetchBucketTaskPriorities();
  }
  
  fetchBuckets() {
    this.bucketService.getBuckets(environment.bucketEndpoint).subscribe(
      (response: any) => {
        this.buckets = response;
      },
      (error: any) => {
      }
    );
  }

  fetchBucketTasks() {
    this.bucketTaskService.getBucketTasks(environment.bucketTaskEndpoint).subscribe(
      (response: any) => {
        this.bucketTasks = response;
        this.bucketTasksToDo = this.bucketTasks.filter(element => element.bucketTaskStateId === 1);
        this.bucketTasksInProgress = this.bucketTasks.filter(element => element.bucketTaskStateId === 2);
        this.bucketTasksDone = this.bucketTasks.filter(element => element.bucketTaskStateId === 3);
        this.bucketTasksCancelled = this.bucketTasks.filter(element => element.bucketTaskStateId === 4);
      },
      (error: any) => {
        this.toastr.error("Request failed")
      }
    );
  }

  fetchBucketTasksStates() {
    this.dictionaryService.getBucketTaskStates(environment.bucketTaskStatesEndpoint).subscribe(
      (response: BucketTaskState[]) => {
        this.bucketTaskStates = response;
      },
      (error: any) => {
        this.toastr.error("Request failed")
      }
    );
  }

  fetchBucketTaskPriorities() {
    this.dictionaryService.getBucketTaskPriorities(environment.bucketTaskPrioritiesEndoint).subscribe(
      (response: BucketTaskPriority[]) => {
        this.bucketTaskPriorities = response;
      },
      (error: any) => {
        this.toastr.error("Request failed")
      }
    );
  }

  RemoveBucket(id: any) {
    this.bucketService.deleteBucket(environment.bucketEndpoint+id).subscribe(
        (response: any) => {
          this.showModal = false;
          this.toastr.success(`Bucket ${this.buckets.find(b => b.id === id).name} deleted successfully.`);
          this.refreshBucketAndBucketsComponents();
        },
        (error: any) => {
          this.toastr.error("Request failed")
        }
    );
  }

  calculateTotalToDoForBucket(id: number) {
    if (this.bucketTasks)
    {
      return this.bucketTasks.filter(task => task.bucketId === id && task.bucketTaskStateId === 1).length ?? 0;
    }
    else
    {
      return 0;
    }
  }

  elementToRemove: Bucket;

  findElementToRemoveById(id: number) {
    return this.buckets.find(element => element.id == id) ?? null;
  }

  showModal = false;

  toggleDeleteModal(i: number, e: Event) {
    this.elementToRemove = this.findElementToRemoveById(i);
    this.showModal = !this.showModal;
    event.stopPropagation();
  }

  exitDeleteModal() {
    this.showModal = !this.showModal;
  }
}