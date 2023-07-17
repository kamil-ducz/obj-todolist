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

    getAssignees(url): Observable<Assignee[]> {
        return this.httpClient.get<Assignee[]>(url);
    }

    getAssignee(url): Observable<Assignee> {
        return this.httpClient.get<Assignee>(url);
    }

    postAssignee(url, assignee: Assignee): Observable<Assignee> {
        return this.httpClient.post<Assignee>(url, assignee);
    }

    putAssignee(url): Observable<Assignee> {
        return this.httpClient.put<Assignee>(url, null);
    }
    
    deleteAssignee(url): Observable<Assignee> {
        return this.httpClient.delete<Assignee>(url);
    }  
}