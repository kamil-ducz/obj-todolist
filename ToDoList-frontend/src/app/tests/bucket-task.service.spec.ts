import { TestBed } from '@angular/core/testing';
import { BucketService } from '../services/bucket.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Bucket } from '../models/bucket.model';
import { BucketTask } from '../models/bucket.task.model';
import { BucketTaskService } from '../services/bucket.task.service';

describe('BucketService', () => {
  let service: BucketTaskService;
  let httpMock: HttpTestingController;
  const fakeBucketTasks: BucketTask[] = [
    {
      id: 1,
      name: 'Mock bucket task one',
      description: 'Mock bucket task one description',
      bucketTaskStateId: 1,
      bucketTaskState: 'ToDo',
      bucketTaskPriorityId: 1,
      bucketTaskPriority: 'High',
      bucketId: 1,
      assigneeId: 1,
    },
    {
      id: 2,
      name: 'Mock bucket task two',
      description: 'Mock bucket task two description',
      bucketTaskStateId: 2,
      bucketTaskState: 'InProgress',
      bucketTaskPriorityId: 2,
      bucketTaskPriority: 'Normal',
      bucketId: 2,
      assigneeId: 2,
    },
    {
      id: 3,
      name: 'Mock bucket task three',
      description: 'Mock bucket task three description',
      bucketTaskStateId: 3,
      bucketTaskState: 'Done',
      bucketTaskPriorityId: 3,
      bucketTaskPriority: 'Low',
      bucketId: 3,
      assigneeId: 3,
    }
  ];
  const fakeBucketTask: BucketTask = {
    id: 4,
    name: 'Mock bucket task four',
    description: 'Mock bucket task four description',
    bucketTaskStateId: 4,
    bucketTaskState: 'Cancelled',
    bucketTaskPriorityId: 0,
    bucketTaskPriority: 'None',
    bucketId: 3,
    assigneeId: 4,
  }

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        BucketTaskService
      ]
    });
    service = TestBed.inject(BucketTaskService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  })

  it('should retrieve bucket tasks', () => {
    service.getBucketTasks().subscribe(
      (bucketTasks: BucketTask[]) => {
        expect(bucketTasks).toEqual(fakeBucketTasks);
      });
      const request = httpMock.expectOne(req => req.method === 'GET');
      expect (request.request.method).toBe('GET');
      request.flush(fakeBucketTasks);
  });

  it('should retrieve single bucket task', () => {
    service.getBucketTask(1).subscribe(
      (bucketTask: BucketTask) => {
        expect(bucketTask).toEqual(fakeBucketTask);
      });
      const request = httpMock.expectOne(req => req.method === 'GET');
      expect (request.request.method).toBe('GET');
      request.flush(fakeBucketTask);
  });

  it('should insert new bucket task', () => {
    service.postBucketTask(fakeBucketTask).subscribe(
      (bucketTask: BucketTask) => {
        expect(bucketTask).toEqual(fakeBucketTask);
      });
      const request = httpMock.expectOne(req => req.method === 'POST');
      expect (request.request.method).toBe('POST');
      request.flush(fakeBucketTask);
  });

  it('should update bucket task', () => {
    service.putBucketTask(1, fakeBucketTask).subscribe(
      (bucketTask: BucketTask) => {
        expect(bucketTask).toEqual(fakeBucketTask);
      });
      const request = httpMock.expectOne(req => req.method === 'PUT');
      expect (request.request.method).toBe('PUT');
      request.flush(fakeBucketTask);
  });

  it('should update bucket', () => {
    service.deleteBucketTask(1).subscribe(
      (bucketTask: BucketTask) => {
        expect(bucketTask).toEqual(fakeBucketTask);
      });
      const request = httpMock.expectOne(req => req.method === 'DELETE');
      expect (request.request.method).toBe('DELETE');
      request.flush(fakeBucketTask);
  });
});
