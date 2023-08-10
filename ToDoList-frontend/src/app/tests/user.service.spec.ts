import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { User } from '../models/user.model';
import { UserService } from '../services/auth/user.service';

describe('UserService', () => {
  let service: UserService;
  let httpMock: HttpTestingController;
  const fakeUsers: User[] = [
    {
    id: 1,
    firstName: 'John',
    lastName: 'Doe',
    username: 'JD',
    email: 'john.doe@alfa.com',
    password: 'test123'
    },
    {
      id: 2,
      firstName: 'Erick',
      lastName: 'Gold',
      username: 'EG',
      email: 'eg@beta.com',
      password: 'test123'
      }
  ];
  const fakeUser: User = {
    id: 1,
    firstName: 'John',
    lastName: 'Doe',
    username: 'JD',
    email: 'john.doe@alfa.com',
    password: 'test123'
  };

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        UserService
      ]
    });
    service = TestBed.inject(UserService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  })

  it('should retrieve users', () => {
    service.GetAllUsers().subscribe(
      (users: User[]) => {
        expect(users).toEqual(fakeUsers);
      });
      const request = httpMock.expectOne(req => req.method === 'GET');
      expect (request.request.method).toBe('GET');
      request.flush(fakeUsers);
  });

  it('should retrieve user', () => {
    service.GetUser(1).subscribe(
      (users: User) => {
        expect(users).toEqual(fakeUser);
      });
      const request = httpMock.expectOne(req => req.method === 'GET');
      expect (request.request.method).toBe('GET');
      request.flush(fakeUser);
  });

  it('should insert user', () => {
    service.postUser(fakeUser).subscribe(
      (user: User) => {
        expect(user).toEqual(fakeUser);
      });
      const request = httpMock.expectOne(req => req.method === 'POST');
      expect (request.request.method).toBe('POST');
      request.flush(fakeUser);
  });
});
