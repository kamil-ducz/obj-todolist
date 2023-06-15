import { HttpClient } from '@angular/common/http';

export class StatsService {
    
    constructor(private httpClient: HttpClient) {}

    getStats(): void {
        this.httpClient.get('https://localhost:7247/api/Stats');
    }

    getStat(id:number): void {
        this.httpClient.get('https://localhost:7247/api/Stats/{id}');
    }

    postStat(id:number): void {
        this.httpClient.post('https://localhost:7247/api/Stats', null); //2nd argument to work out TODO
    }

    putStat(id:number): void {
        this.httpClient.put('https://localhost:7247/api/Stats', null);
    }

    deleteStat(id:number): void {
        this.httpClient.delete('https://localhost:7247/api/Stats');
    }
}