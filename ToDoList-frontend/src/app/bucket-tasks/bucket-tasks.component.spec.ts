import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BucketTasksComponent } from './bucket-tasks.component';

describe('BucketTasksComponent', () => {
  let component: BucketTasksComponent;
  let fixture: ComponentFixture<BucketTasksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BucketTasksComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BucketTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
