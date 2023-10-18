import { Component, OnInit } from '@angular/core';
import { BucketService } from '../services/bucket.service';
import { BucketTaskService } from '../services/bucket.task.service';
import { Bucket } from '../models/bucket.model';
import { BucketTask } from '../models/bucket.task.model';
import { ToastrService } from 'ngx-toastr';
import { BucketTaskState } from '../models/bucket.task.state.model';
import { BucketTaskPriority } from '../models/bucket.task.priority.model';
import { DictionaryService } from '../services/dictionary.service';
import { PaginatedBucketResult } from '../models/paginated.bucket.result.model';

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
  // Server pagination variables  
  paginatedBucketResult: PaginatedBucketResult;
  paginatedBuckets: Bucket[];
  // Client pagination variables
  searchPhrase: string;
  currentPage: number = 1;
  itemsPerPage: number = 15;

  ngOnInit() {
    this.refreshBucketAndBucketsComponents();
  }

  refreshBucketAndBucketsComponents() {
    this.fetchBuckets(); // to be removed
    this.fetchPaginatedBuckets();
    this.fetchBucketTasks();
    this.fetchBucketTasksStates();
    this.fetchBucketTaskPriorities();
  }

  fetchPaginatedBuckets() {
    this.bucketService.getPaginatedBuckets(this.searchPhrase, this.currentPage, this.itemsPerPage).subscribe(
      (response: PaginatedBucketResult) => {
        this.paginatedBucketResult = response;
        this.paginatedBuckets = response.bucketsBatch;
        console.log("response in JSON = " + JSON.stringify(response));
        console.log("this.paginatedBucketResult = " + JSON.stringify(this.paginatedBucketResult));
      }
    )
  }
  
  fetchBuckets() {
    this.bucketService.getBuckets().subscribe(
      (response: any) => {
        this.buckets = response;
      }
    );
  }

  fetchBucketTasks() {
    this.bucketTaskService.getBucketTasks().subscribe(
      (response: any) => {
        this.bucketTasks = response;
        this.bucketTasksToDo = this.bucketTasks.filter(element => element.bucketTaskStateId === 1);
        this.bucketTasksInProgress = this.bucketTasks.filter(element => element.bucketTaskStateId === 2);
        this.bucketTasksDone = this.bucketTasks.filter(element => element.bucketTaskStateId === 3);
        this.bucketTasksCancelled = this.bucketTasks.filter(element => element.bucketTaskStateId === 4);
      }
    );
  }

  fetchBucketTasksStates() {
    this.dictionaryService.getBucketTaskStates().subscribe(
      (response: BucketTaskState[]) => {
        this.bucketTaskStates = response;
      }
    );
  }

  fetchBucketTaskPriorities() {
    this.dictionaryService.getBucketTaskPriorities().subscribe(
      (response: BucketTaskPriority[]) => {
        this.bucketTaskPriorities = response;
      }
    );
  }

  RemoveBucket(id: any) {
    this.bucketService.deleteBucket(id).subscribe(
        (response: any) => {
          this.showModal = false;
          this.toastr.success(`Bucket ${this.buckets.find(b => b.id === id).name} deleted successfully.`);
          this.refreshBucketAndBucketsComponents();
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