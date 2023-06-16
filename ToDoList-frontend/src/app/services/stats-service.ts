import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { Stat } from '../models/stat.model';

@Injectable ({
    providedIn: 'root'
})

export class StatsService {
    
    constructor(private httpClient: HttpClient) {}

    getStats() {
        return this.httpClient.get('https://localhost:7247/api/Stats');
    }

    getStat(id:number): Observable<Stat> {
        return this.httpClient.get<Stat>('https://localhost:7247/api/Stats/'+id);
    }

    postStat(id:number) {
        return this.httpClient.post('https://localhost:7247/api/Stats', null); //2nd argument to work out TODO
    }

    putStat(id:number) {
        return this.httpClient.put('https://localhost:7247/api/Stats', null);
    }

    deleteStat(id:number) {
        return this.httpClient.delete('https://localhost:7247/api/Stats');
    }
    
}