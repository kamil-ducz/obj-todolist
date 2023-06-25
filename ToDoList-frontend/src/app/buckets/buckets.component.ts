import { Component, OnInit } from '@angular/core';
import { BucketService } from '../services/bucket-service';
import { BucketTaskService } from '../services/buckettask-service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-buckets',
  templateUrl: './buckets.component.html',
  styleUrls: ['./buckets.component.css']
})
export class BucketsComponent implements OnInit {

  constructor(private bucketService: BucketService, private bucketTaskService: BucketTaskService) { }

  buckets: any;

  bucketTasks;
  bucketTasksToDo: any;
  bucketTasksInProgress: any;
  bucketTasksDone: any;
  bucketTasksCancelled: any;

  ngOnInit() {
    this.bucketService.getBuckets(environment.bucketEndpoint).subscribe(
      (response: any) => {
        this.buckets = response;
      },
      (error: any) => {
        console.error(error);
      }
    );

    this.bucketTaskService.getBucketTasks(environment.bucketTaskEndpoint).subscribe(
      (response: any) => {
        this.bucketTasks = response;
        this.bucketTasksToDo = this.bucketTasks.filter(element => element.taskState == 0);
        this.bucketTasksInProgress = this.bucketTasks.filter(element => element.taskState == 1);
        this.bucketTasksDone = this.bucketTasks.filter(element => element.taskState == 2);
        this.bucketTasksCancelled = this.bucketTasks.filter(element => element.taskState == 3);
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  RemoveBucket(id: any) {
    this.bucketService.deleteBucket(environment.bucketEndpoint+id).subscribe(
        (response: any) => {
          this.showModal = !this.showModal;
          this.ngOnInit();
        },
        (error: any) => {
          console.error(error);
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

  elementToRemove: any;

  findElementToRemoveById(id: number) {
    const foundElement = this.buckets.find(element => element.id == id);
    if(foundElement)
    {
      return foundElement;
    }
    else
    {
      return;
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
}