import { Component, OnInit } from '@angular/core';
import { StatsService } from '../services/stats-service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {

  constructor(private statsService:StatsService) { }

  statData: any;
  percentOfTasksToDo: number = 0;
  percentOfTasksInProgress: number = 0;
  percentOfTasksCompleted: number = 0;
  percentOfTasksCancelled: number = 0;

  ngOnInit(): void {
    // getStat(id) where id should be currently logged user AssigneId TODO

    this.statsService.getStat(8).subscribe(
      (response: any) => {
        this.statData = response;
        this.percentOfTasksToDo = response.percentOfTasksToDo;
        this.percentOfTasksInProgress = response.percentOfTasksInProgress;
        this.percentOfTasksCompleted = response.percentOfTasksCompleted;
        this.percentOfTasksCancelled = response.percentOfTasksCancelled;
      },
      (error: any) => {
        console.error(error);        
      }
    );
  }
}