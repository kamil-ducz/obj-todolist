import { HttpClient } from "@angular/common/http";

export class AssigneeService {

    constructor(private httpClient: HttpClient) {}

    getAssignees(): void {
        this.httpClient.get('https://localhost:7247/api/Assignee');
    }

    getAssignee(id:number): void {
        this.httpClient.get('https://localhost:7247/api/Assignee/{id}');
    }

    postAssignee(id:number): void {
        this.httpClient.post('https://localhost:7247/api/Assignee', null); //2nd argument to work out TODO
    }

    putAssignee(id:number): void {
        this.httpClient.put('https://localhost:7247/api/Assignee', null);
    }
    
    deleteAssignee(id:number): void {
        this.httpClient.delete('https://localhost:7247/api/Assignee');
    }
    
}