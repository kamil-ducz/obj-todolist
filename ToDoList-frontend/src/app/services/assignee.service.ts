import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Assignee } from "../models/assignee.model";
import { Observable } from "rxjs";

@Injectable ({
    providedIn: 'root'
})

export class AssigneeService {

    constructor(
        private httpClient: HttpClient
    ) {}

    getAssignees(): Observable<Assignee[]> {
        return this.httpClient.get<Assignee[]>('Assignee/');
    }

    getAssignee(assigneeId: number): Observable<Assignee> {
        return this.httpClient.get<Assignee>('Assignee/'+assigneeId);
    }

    postAssignee(newAssignee: Assignee): Observable<Assignee> {
        return this.httpClient.post<Assignee>('Assignee/', newAssignee);
    }

    putAssignee(assigneeId: number, updatedAssignee: Assignee): Observable<Assignee> {
        return this.httpClient.put<Assignee>('Assignee/'+assigneeId, updatedAssignee);
    }
    
    deleteAssignee(assigneeId: number): Observable<Assignee> {
        return this.httpClient.delete<Assignee>('Assignee/'+assigneeId);
    }  
}