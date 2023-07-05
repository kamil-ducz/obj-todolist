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

    getAssignees(url): Observable<Assignee> {
        return this.httpClient.get<Assignee>(url);
    }

    getAssignee(url) {
        return this.httpClient.get(url);
    }

    postAssignee(url) {
        return this.httpClient.post(url, null);
    }

    putAssignee(url) {
        return this.httpClient.put(url, null);
    }
    
    deleteAssignee(url) {
        return this.httpClient.delete(url);
    }  
}