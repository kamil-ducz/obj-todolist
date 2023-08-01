import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private httpClient: HttpClient
  ) { }

  GetAllUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>('User/');
  }

  GetUser(userId: number): Observable<User> {
    return this.httpClient.get<User>('User/' + userId);
  }
}
