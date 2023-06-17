import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Assignee } from "../models/assignee.model";
import { Observable } from "rxjs";

@Injectable ({
    providedIn: 'root'
})

export class AssigneeService {

    constructor(private httpClient: HttpClient) {}

    getAssignees(): Observable<Assignee> {
        return this.httpClient.get<Assignee>('https://localhost:7247/api/Assignee');
    }

    getAssignee(id:number) {
        return this.httpClient.get('https://localhost:7247/api/Assignee/{id}');
    }

    postAssignee(id:number) {
        return this.httpClient.post('https://localhost:7247/api/Assignee', null); //2nd argument to work out TODO
    }

    putAssignee(id:number) {
        return this.httpClient.put('https://localhost:7247/api/Assignee', null);
    }
    
    deleteAssignee(id:number) {
        return this.httpClient.delete('https://localhost:7247/api/Assignee');
    }
    
}