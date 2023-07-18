import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { AssigneeService } from './assignee-service';
import { Assignee } from '../models/assignee.model';

describe('AssigneeService', () => {
  let service: AssigneeService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [AssigneeService]
    });

    service = TestBed.inject(AssigneeService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should retrieve assignees from API', () => {
    const fakeAssignees: Assignee[] = [
      { id: 1, name: 'Assignee 1' },
      { id: 2, name: 'Assignee 2' }
    ];

    service.getAssignees('https://example.com/api/assignees').subscribe((assignees: Assignee[]) => {
      expect(assignees).toEqual(fakeAssignees);
    });

    const request = httpMock.expectOne('https://example.com/api/assignees');
    expect(request.request.method).toBe('GET');
    request.flush(fakeAssignees);
  });

  // Add more test cases for other methods of AssigneeService
});
