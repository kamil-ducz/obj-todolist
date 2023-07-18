import { TestBed } from '@angular/core/testing';
import { BucketService } from '../services/bucket-service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Bucket } from '../models/bucket.model';
import { BucketTask } from '../models/bucket-task.model';

describe('BucketService', () => {
  let service: BucketService;
  let httpMock: HttpTestingController;
  const fakeBuckets: Bucket[] = [
    {
    id: 1,
    name: 'Mock bucket one',
    description: 'Mock bucket one description',
    bucketColorId: 1,
    bucketColor: 'Brown',
    bucketCategoryId: 1,
    bucketCategory: 'Work',
    maxAmountOfTasks: 15,
    isActive: true
    },
    {
      id: 2,
      name: 'Mock bucket two',
      description: 'Mock bucket two description',
      bucketColorId: 2,
      bucketColor: 'Red',
      bucketCategoryId: 2,
      bucketCategory: 'Home',
      maxAmountOfTasks: 5,
      isActive: false
      }
  ];
  const fakeBucket: Bucket = {
    id: 3,
    name: 'Mock bucket three',
    description: 'Mock bucket three description',
    bucketColorId: 3,
    bucketColor: 'Yellow',
    bucketCategoryId: 3,
    bucketCategory: 'Hobby',
    maxAmountOfTasks: 1,
    isActive: true
  };
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

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        BucketService
      ]
    });
    service = TestBed.inject(BucketService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  })

  it('should retrieve buckets', () => {
    service.getBuckets('mock/api/bucket').subscribe(
      (buckets: Bucket[]) => {
        expect(buckets).toEqual(fakeBuckets);
      });
      const request = httpMock.expectOne('mock/api/bucket');
      expect (request.request.method).toBe('GET');
      request.flush(fakeBuckets);
  });

  it('should retrieve bucket', () => {
    service.getBucket('mock/api/bucket').subscribe(
      (buckets: Bucket) => {
        expect(buckets).toEqual(fakeBucket);
      });
      const request = httpMock.expectOne('mock/api/bucket');
      expect (request.request.method).toBe('GET');
      request.flush(fakeBucket);
  });

  it('should retrieve bucket tasks', () => {
    service.getBucketTasks('mock/api/bucket-tasks').subscribe(
      (bucketTasks: BucketTask[]) => {
        expect(bucketTasks).toEqual(fakeBucketTasks);
      });
      const request = httpMock.expectOne('mock/api/bucket-tasks');
      expect (request.request.method).toBe('GET');
      request.flush(fakeBucketTasks);
  });

  it('should insert bucket', () => {
    service.postBucket('mock/api/bucket', fakeBucket).subscribe(
      (bucket: Bucket) => {
        expect(bucket).toEqual(fakeBucket);
      });
      const request = httpMock.expectOne('mock/api/bucket');
      expect (request.request.method).toBe('POST');
      request.flush(fakeBucket);
  });

  it('should update bucket', () => {
    service.putBucket('mock/api/bucket', fakeBucket).subscribe(
      (buckets: Bucket) => {
        expect(buckets).toEqual(fakeBucket);
      });
      const request = httpMock.expectOne('mock/api/bucket');
      expect (request.request.method).toBe('PUT');
      request.flush(fakeBucket);
  });

  it('should delete bucket', () => {
    service.deleteBucket('mock/api/bucket').subscribe(
      (buckets: Bucket) => {
        expect(buckets).toEqual(fakeBucket);
      });
      const request = httpMock.expectOne('mock/api/bucket');
      expect (request.request.method).toBe('DELETE');
      request.flush(fakeBucket);
  });
});
