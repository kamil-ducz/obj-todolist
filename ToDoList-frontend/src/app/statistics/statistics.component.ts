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
  ToDo: number = 0;
  InProgress: number = 0;
  Completed: number = 0;
  Cancelled: number = 0;

  ngOnInit(): void {
    // getStat(id) where id should be currently logged user AssigneId TODO

    this.statsService.getStat(8).subscribe(
      (response: any) => {
        this.statData = response;
        this.ToDo = response.toDo;
        this.InProgress = response.inProgress;
        this.Completed = response.completed;
        this.Cancelled = response.cancelled;
      },
      (error: any) => {
        console.error(error);        
      }
    );
  }
}