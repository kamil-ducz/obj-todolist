import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { AssigneeService } from '../services/assignee-service';
import { Assignee } from '../models/assignee.model';

describe('AssigneeService', () => {
  let service: AssigneeService;
  let httpMock: HttpTestingController;
  const fakeAssignee: Assignee = { id: 1, name: 'Assignee 1' };
  const fakeAssignees: Assignee[] = [
    { id: 1, name: 'Assignee 1' },
    { id: 2, name: 'Assignee 2' }
  ];

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

  it('should retrieve assignees', () => {
    service.getAssignees('mock/api/assignees').subscribe((assignees: Assignee[]) => {
      expect(assignees).toEqual(fakeAssignees);
    });
    const request = httpMock.expectOne('mock/api/assignees');
    expect(request.request.method).toBe('GET');
    request.flush(fakeAssignees);
  });

  it('should retrieve single assignee', () => {
    service.getAssignee('mock/api/assignee').subscribe((assignee: Assignee) => {
      expect(assignee).toEqual(fakeAssignee);
    });
    const request = httpMock.expectOne('mock/api/assignee');
    expect(request.request.method).toBe('GET');
    request.flush(fakeAssignee);
  });

  it('should insert single assignee', () => {
    service.postAssignee('mock/api/assignee', fakeAssignee).subscribe((assignee: Assignee) => {
      expect(assignee).toEqual(fakeAssignee);
    });
    const request = httpMock.expectOne('mock/api/assignee');
    expect(request.request.method).toBe('POST');
    request.flush(fakeAssignee);
  });

  it('should update single assignee', () => {
    service.putAssignee('mock/api/assignee').subscribe((assignee: Assignee) => {
      expect(assignee).toEqual(fakeAssignee);
    });
    const request = httpMock.expectOne('mock/api/assignee');
    expect(request.request.method).toBe('PUT');
    request.flush(fakeAssignee);
  });

  it('should delete single assignee', () => {
    service.deleteAssignee('mock/api/assignee').subscribe((assignee: Assignee) => {
      expect(assignee).toEqual(fakeAssignee);
    });

    const request = httpMock.expectOne('mock/api/assignee');
    expect(request.request.method).toBe('DELETE');
    request.flush(fakeAssignee);
  });
});
