import { Component, OnInit } from '@angular/core';
import { AssigneeService } from '../services/assignee-service';

@Component({
  selector: 'app-assignees',
  templateUrl: './assignees.component.html',
  styleUrls: ['./assignees.component.css']
})
export class AssigneesComponent implements OnInit {

  constructor(private assigneeService: AssigneeService) { }

  assignessData: any;

  ngOnInit(): void {
    this.assigneeService.getAssignees().subscribe(
      (response: any) => {
        this.assignessData = response;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }
}