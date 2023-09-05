import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";
import { AuthenticationService } from "../services/auth/authentication.service";
import { User } from "../models/user.model";
import { TestBed } from "@angular/core/testing";
import { getLocaleMonthNames } from "@angular/common";

describe('AuthenticationService tests', () => {
    let service: AuthenticationService;
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
                AuthenticationService
            ]
        });
        service = TestBed.inject(AuthenticationService);
        httpMock = TestBed.inject(HttpTestingController);
    });

    afterEach(() => {
        httpMock.verify();
        localStorage.removeItem('user');
    })

    it('Should perform successfull login operation', () => {
        const fakeResponse = { 
            id: 1,
            firstName: 'John',
            lastName: 'Doe',
            username: 'JD',
            email: 'john.doe@alfa.com',
            password: 'test123'
         };
        service.login(fakeUsers[0].username, fakeUsers[0].password).subscribe(
            (response: any) => {
                expect(response).toEqual(fakeResponse);
                const userLocalStorage = localStorage.getItem('user');
                expect(userLocalStorage).toBeTruthy();
            }
        );
        const request = httpMock.expectOne('Users/authenticate');
        expect(request.request.method).toBe('POST');
        request.flush(fakeResponse);
    });
});