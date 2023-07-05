import { Component, OnInit } from '@angular/core';
import { AssigneeService } from '../services/assignee-service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-assignees',
  templateUrl: './assignees.component.html',
  styleUrls: ['./assignees.component.css']
})
export class AssigneesComponent implements OnInit {

  constructor(private assigneeService: AssigneeService) { }

  assigness: any;

  ngOnInit(): void {
    this.assigneeService.getAssignees(environment.localhostUrl).subscribe(
      (response: any) => {
        this.assigness = response;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }
}