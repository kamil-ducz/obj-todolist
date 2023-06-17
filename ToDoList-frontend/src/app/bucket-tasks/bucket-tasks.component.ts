import { Component, OnInit } from '@angular/core';
import { BucketTaskService } from '../services/buckettask-service';

@Component({
  selector: 'app-bucket-tasks',
  templateUrl: './bucket-tasks.component.html',
  styleUrls: ['./bucket-tasks.component.css']
})
export class BucketTasksComponent implements OnInit {

  constructor(private bucketTaskService: BucketTaskService) { }

  bucketTasksData: any;

  ngOnInit(): void {
    this.bucketTaskService.getBucketTasks().subscribe(
      (response: any) => {
        this.bucketTasksData = response;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }
}
