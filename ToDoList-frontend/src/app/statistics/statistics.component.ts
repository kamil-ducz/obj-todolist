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

  ngOnInit(): void {

    this.statsService.getStat(8).subscribe(
      (response: any) => {
        this.statData = response;
      },
      (error: any) => {
        console.error(error);        
      }
    );
  }
}