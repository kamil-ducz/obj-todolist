import { Component, OnInit } from '@angular/core';
import { BucketService } from '../services/bucket-service';
import { BucketTaskService } from '../services/buckettask-service';
import { BucketTask } from '../models/buckettask.model';

@Component({
  selector: 'app-buckets',
  templateUrl: './buckets.component.html',
  styleUrls: ['./buckets.component.css']
})
export class BucketsComponent implements OnInit {

  constructor(private bucketService: BucketService, private bucketTaskService: BucketTaskService) { }

  bucketsData: any;

  bucketTasksData;
  bucketTasksToDo: any;
  bucketTasksInProgress: any;
  bucketTasksDone: any;
  bucketTasksCancelled: any;

  ngOnInit() {
    this.bucketService.getBuckets('https://localhost:7247/api/Bucket').subscribe(
      (response: any) => {
        this.bucketsData = response;
      },
      (error: any) => {
        console.error(error);
      }
    );

    this.bucketTaskService.getBucketTasks('https://localhost:7247/api/BucketTask').subscribe(
      (response: any) => {
        this.bucketTasksData = response;
        this.bucketTasksToDo = this.bucketTasksData.filter(element => element.taskState == 0);
        this.bucketTasksInProgress = this.bucketTasksData.filter(element => element.taskState == 1);
        this.bucketTasksDone = this.bucketTasksData.filter(element => element.taskState == 2);
        this.bucketTasksCancelled = this.bucketTasksData.filter(element => element.taskState == 3);
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  RemoveBucket(id: any) {
    this.bucketService.deleteBucket('https://localhost:7247/api/Bucket/'+id).subscribe(
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
    if (this.bucketTasksData)
    {
      const tasksForBucket = this.bucketTasksData.filter(task => task.bucketId === id && task.taskState === 0);

      return tasksForBucket.length;
    }
    else
    {
      return 0;
    }
  }

  elementToRemove: any;

  findElementToRemoveById(id: number) {
    const foundElement = this.bucketsData.find(element => element.id == id);
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