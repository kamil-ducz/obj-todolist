import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { BucketService } from '../services/bucket-service';
import { Bucket } from '../models/bucket.model';
import { BucketTaskService } from '../services/buckettask-service';

@Component({
  selector: 'app-bucket',
  templateUrl: './bucket.component.html',
  styleUrls: ['./bucket.component.css']
})
export class BucketComponent implements OnInit {

  id: number;

  currentBucket: Bucket;

  currentBucketBucketTasks: any;
  bucketTasksToDo: any;
  bucketTasksInProgress: any;
  bucketTasksDone: any;
  bucketTasksCancelled: any;

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

  showModal = false;

  toggleDeleteModal(i: number, e: Event) {
    this.showModal = !this.showModal;
    event.stopPropagation();
  }

  exitDeleteModal() {
    this.showModal = !this.showModal;
  }

}
