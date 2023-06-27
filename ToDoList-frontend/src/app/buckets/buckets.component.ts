import { Component, OnInit } from '@angular/core';
import { BucketService } from '../services/bucket-service';
import { BucketTaskService } from '../services/buckettask-service';
import { environment } from 'src/environments/environment';
import { Bucket } from '../models/bucket.model';
import { BucketTask } from '../models/buckettask.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-buckets',
  templateUrl: './buckets.component.html',
  styleUrls: ['./buckets.component.css']
})
export class BucketsComponent implements OnInit {

  constructor(private bucketService: BucketService, private bucketTaskService: BucketTaskService, private toastr: ToastrService) { }

  refreshBucketAndBucketsComponents() {
    this.fetchBuckets();
    this.fetchBucketTasks();
  }

  buckets: Bucket[];
  bucketColorClass: string;

  fetchBuckets() {
    this.bucketService.getBuckets(environment.bucketEndpoint).subscribe(
      (response: any) => {
        this.buckets = response;
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.")
      }
    );
  }

  bucketTasks: BucketTask[];
  bucketTasksToDo: BucketTask[];
  bucketTasksInProgress: BucketTask[];
  bucketTasksDone: BucketTask[];
  bucketTasksCancelled: BucketTask[];

  fetchBucketTasks() {
    this.bucketTaskService.getBucketTasks(environment.bucketTaskEndpoint).subscribe(
      (response: any) => {
        this.bucketTasks = response;
        this.bucketTasksToDo = this.bucketTasks.filter(element => element.taskState == 0);
        this.bucketTasksInProgress = this.bucketTasks.filter(element => element.taskState == 1);
        this.bucketTasksDone = this.bucketTasks.filter(element => element.taskState == 2);
        this.bucketTasksCancelled = this.bucketTasks.filter(element => element.taskState == 3);
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.")
      }
    );
  }

  ngOnInit() {
    this.refreshBucketAndBucketsComponents();
  }

  RemoveBucket(id: any) {
    this.bucketService.deleteBucket(environment.bucketEndpoint+id).subscribe(
        (response: any) => {
          this.showModal = !this.showModal;
          this.refreshBucketAndBucketsComponents();
        },
        (error: any) => {
          this.toastr.error("Request failed. Check console logs and network tab to identify the issue.")
        }
    );
  }

  calculateTotalToDoForBucket(id: number) {
    if (this.bucketTasks)
    {
      const tasksForBucket = this.bucketTasks.filter(task => task.bucketId === id && task.taskState === 0);

      return tasksForBucket.length;
    }
    else
    {
      return 0;
    }
  }

  elementToRemove: Bucket;

  findElementToRemoveById(id: number) {
    const foundElement = this.buckets.find(element => element.id == id);
    if(foundElement)
    {
      return foundElement;
    }
    else
    {
      return null;
    }
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

  setBucketColorClass(bucket: Bucket) {
    switch(bucket.bucketColor) {
      case 0: {
        return 'bg-yellow-900';
      }
      case 1: {
        return 'bg-red-500';
      }
      case 2: {
        return 'bg-yellow-500';
      }
      case 3: {
        return 'bg-blue-500';
      }
      case 4: {
        return 'bg-white';
      }
      case 5: {
        return 'bg-green-500'
      }
      default: {
        return 'bg-white';
      }
    }
  }
}