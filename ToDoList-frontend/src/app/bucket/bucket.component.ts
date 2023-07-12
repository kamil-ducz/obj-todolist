import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { BucketService } from '../services/bucket-service';
import { Bucket } from '../models/bucket.model';
import { BucketTaskService } from '../services/buckettask-service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BucketTask } from '../models/bucketTask.model';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';
import { DictionaryService } from '../services/dictionary.service';
import { BucketTaskState } from '../models/bucketTaskState.model';
import { BucketTaskPriority } from '../models/bucketTaskPriority.model';
import { BucketCategory } from '../models/bucketCategory.model';
import { BucketColor } from '../models/bucketColor.model';
import { Assignee } from '../models/assignee.model';
import { AssigneeService } from '../services/assignee-service';

@Component({
  selector: 'app-bucket',
  templateUrl: './bucket.component.html',
  styleUrls: ['./bucket.component.css']
})
export class BucketComponent implements OnInit {

  constructor(
    private route: ActivatedRoute, 
    private router: Router, 
    private bucketService: BucketService, 
    private bucketTaskService: BucketTaskService, 
    private dictionaryService: DictionaryService, 
    private toastr: ToastrService,
    private assigneeService: AssigneeService
    ) { }

  currentBucketId: number;
  currentBucket: Bucket;
  currentBucketCategoryName: string;
  bucketCategories: BucketCategory[];
  bucketColors: BucketColor[];

  currentBucketBucketTasks: BucketTask[];
  currentBucketTask: BucketTask;
  bucketTaskForEditSaveId: number;
  bucketTaskStates: BucketTaskState[];
  bucketTaskPriorities: BucketTaskPriority[];
  bucketTasksToDo: BucketTask[];
  bucketTasksInProgress: BucketTask[];
  bucketTasksDone: BucketTask[];
  bucketTasksCancelled: BucketTask[];

  assignees: Assignee[];
  showAssigneeListItems = false;
  assigneeControl = new FormControl();

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.currentBucketId = +params['id'];
      }
    );
    this.refreshCurrentBucketBucketTasksComponents();
  }
  
  refreshCurrentBucketBucketTasksComponents() {
    this.fetchBucketCategories();
    this.fetchCurrentBucket();
    this.fetchBucketTasks();
    this.fetchBucketTasksStates();
    this.fetchBucketTaskPriorities();
    this.fetchAssigness();
  }

  showAssigneeList() {
    this.showAssigneeListItems = !this.showAssigneeListItems;
  }

  selectAssignee(assignee: Assignee) {
    setTimeout(() => {
      if (this.showNewBucketTaskForm)
      {
        this.addNewBucketTaskFormGroup.patchValue({ assigneeControl:assignee.name });
      }
      if (this.showEditBucketTaskForm)
      {
        this.editNewBucketTaskFormGroup.patchValue({ assigneeControl:assignee.name });
      }
    });
    this.showAssigneeListItems = false;
  }

  fetchCurrentBucket() {
    this.bucketService.getBucket(environment.bucketEndpoint+this.currentBucketId).subscribe(
      (response: Bucket) => {
        this.currentBucket = response;
        this.currentBucketCategoryName = this.bucketCategories.find(bcat => bcat.id === this.currentBucket.bucketCategoryId).name;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  fetchBucketCategories() {
    this.dictionaryService.getBucketCategories(environment.bucketCategoryEndpoint).subscribe(
      (response: BucketCategory[]) => {
        this.bucketCategories = response;
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name)
      }
    );
  }

  fetchBucketTasks() {
    this.bucketService.getBucketTasks(environment.buckeTasksForBucketEndpoint+this.currentBucketId).subscribe(
      (response: any) => {
        this.currentBucketBucketTasks = response;
        this.bucketTasksToDo = this.currentBucketBucketTasks.filter(element => element.bucketTaskStateId == 1);
        this.bucketTasksInProgress = this.currentBucketBucketTasks.filter(element => element.bucketTaskStateId == 2);
        this.bucketTasksDone = this.currentBucketBucketTasks.filter(element => element.bucketTaskStateId == 3);
        this.bucketTasksCancelled = this.currentBucketBucketTasks.filter(element => element.bucketTaskStateId == 4);
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  fetchBucketTasksStates() {
    this.dictionaryService.getBucketTaskStates(environment.bucketTaskStatesEndpoint).subscribe(
      (response: BucketTaskState[]) => {
        this.bucketTaskStates = response;
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name)
      }
    );
  }

  fetchBucketTaskPriorities() {
    this.dictionaryService.getBucketTaskPriorities(environment.bucketTaskPrioritiesEndoint).subscribe(
      (response: BucketTaskPriority[]) => {
        this.bucketTaskPriorities = response;
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name)
      }
    );
  }

  fetchAssigness() {
    this.assigneeService.getAssignees(environment.assigneeEndpoint).subscribe(
      (response: Assignee[]) => {
        this.assignees = response;
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name)
      }
    );
  }

  newBucketTaskToCreate: BucketTask;
  addNewBucketTaskFormGroup: FormGroup;
  editNewBucketTaskFormGroup: FormGroup;

  initializeNewBucketTaskForm() {
    this.addNewBucketTaskFormGroup = new FormGroup({
      name: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new FormControl('', [
        Validators.maxLength(50),
      ]),
      bucketTaskState: new FormControl('', [
        Validators.required,      
      ]),
      bucketTaskPriority: new FormControl('', [
        Validators.required,
      ]),
      assigneeControl: new FormControl('', [
        Validators.required,
      ])
    });
  }

  initializeEditBucketTaskForm() {
    const bucketTaskState = this.bucketTaskStates.find(bts => bts.id === this.currentBucketTask.bucketTaskStateId).name;
    const bucketTaskPriority = this.bucketTaskPriorities.find(btps => btps.id === this.currentBucketTask.bucketTaskPriorityId).name;
    const assigneeName = this.assignees.find(a => a.id == this.currentBucketTask.assigneeId).name;

    this.editNewBucketTaskFormGroup = new FormGroup({
      name: new FormControl(this.currentBucketTask.name, [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new FormControl(this.currentBucketTask.description, [
        Validators.maxLength(50),
      ]),
      bucketTaskState: new FormControl(bucketTaskState, [
        Validators.required,      
      ]),
      bucketTaskPriority: new FormControl(bucketTaskPriority, [
        Validators.required,
      ]),
      assigneeControl: new FormControl(assigneeName, [
        Validators.required,
      ])
    });
  }

  onSubmitNewBucketTask(newBucketTask: BucketTask) {
    this.currentBucketTask = newBucketTask;
    this.currentBucketTask.bucketTaskStateId = this.bucketTaskStates.find(bs => bs.name === this.currentBucketTask.bucketTaskState).id;
    this.currentBucketTask.bucketTaskPriorityId = this.bucketTaskPriorities.find(bp => bp.name === this.currentBucketTask.bucketTaskPriority).id;
    this.currentBucketTask.assigneeId = this.assignees.find(a => a.name === this.addNewBucketTaskFormGroup.value.assigneeControl).id;
    this.currentBucketTask.bucketTaskState = null;
    this.currentBucketTask.bucketTaskPriority = null;
    this.currentBucketTask.bucketId = this.currentBucketId;    

    if (this.currentBucketBucketTasks.length < this.currentBucket.maxAmountOfTasks)
    {
      this.bucketTaskService.postBucketTask(environment.bucketTaskEndpoint, this.currentBucketTask).subscribe(
        (response) => {
          this.addNewBucketTaskFormGroup.patchValue({ });
          this.toastr.success("Bucket task " + this.currentBucketTask.name + " created successfully.");
        },
        (error: any) => {
          this.toastr.error("Request failed. Check console logs and network tab to identify the issue." + error.name)
        }
      );
    }
    else 
    {
      this.popNewBucketTaskMaxAmountOfTasksReachedWarning();
      return null;
    }
  }

  onSubmitEditBucketTask(newBucketTask: BucketTask) {
    this.currentBucketTask = this.editNewBucketTaskFormGroup.value;
    this.currentBucketTask.bucketId = this.currentBucketId;
    this.currentBucketTask.bucketTaskStateId = this.bucketTaskStates.find(bts => bts.name === newBucketTask.bucketTaskState).id;
    this.currentBucketTask.bucketTaskPriorityId = this.bucketTaskPriorities.find(btps => btps.name === newBucketTask.bucketTaskPriority).id;
    this.currentBucketTask.assigneeId = this.assignees.find(a => a.name === this.editNewBucketTaskFormGroup.value.assigneeControl).id;
    this.currentBucketTask.bucketTaskState = null;
    this.currentBucketTask.bucketTaskPriority = null;

    this.bucketTaskService.putBucketTask(environment.bucketTaskEndpoint+this.bucketTaskForEditSaveId, this.currentBucketTask).subscribe(
      (response: any) => {
        this.toastr.success("Bucket task " + this.currentBucketTask.name + " changes saved successfully.");
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  removeBucket(id: any) {
    this.bucketService.deleteBucket(environment.bucketEndpoint+id).subscribe(
        (response: any) => {
          this.toastr.success("Bucket " +this.currentBucket.name + " deleted successfully.");
          this.router.navigate(['/buckets']);
        },
        (error: any) => {
          this.toastr.error("Request failed. Check console logs and network tab to identify the issue.")
        }
    );
  }

  removeBucketTask(bucketTaskId: number) {
    this.bucketTaskService.deleteBucketTask(environment.bucketTaskEndpoint+bucketTaskId).subscribe(
      (response: any) => {
        this.fetchBucketTasks();
        this.toastr.success("Bucket task " + this.currentBucketTask.name + " deleted successfully.");
        this.exitDeleteBucketTaskConfirmationModal();
      },
      (error: any) => {
        this.toastr.error("Request failed. Check console logs and network tab to identify the issue.")
      }
    );
  }

  showModal = false;
  searchIcon: string = 'search-icon';

  toggleDeleteModal(i: number, e: Event) {
    this.showModal = !this.showModal;
    event.stopPropagation();
  }

  showNewBucketTaskForm = false;
  showEditBucketTaskForm = false;
  bucketTaskEditConfirmationModal = false;
  bucketTaskDeleteConfirmationModal = false;

  popupNewBucketTaskForm() {
    this.showNewBucketTaskForm = !this.showNewBucketTaskForm;
    this.initializeNewBucketTaskForm();
    //this.addNewBucketTaskFormGroup.patchValue({ assigneeControl: this.selectAssignee() });
  }

  exitNewBucketTaskForm() {
    this.showNewBucketTaskForm = !this.showNewBucketTaskForm;
    this.refreshCurrentBucketBucketTasksComponents();
  }

  exitNewBucketTaskConfirmationModal() {
    this.exitNewBucketTaskForm();
  }

  popEditBucketTaskForm(bucketTaskId: number) {
    this.showEditBucketTaskForm = !this.showEditBucketTaskForm;
    this.currentBucketTask = this.currentBucketBucketTasks.find(element => element.id == bucketTaskId);
    this.bucketTaskForEditSaveId = bucketTaskId;
    this.initializeEditBucketTaskForm();
  }

  exitEditBucketTaskForm() {
    this.showEditBucketTaskForm = false;
    this.refreshCurrentBucketBucketTasksComponents();
  }

  exitEditBucketTaskConfirmationModal() {
    this.bucketTaskEditConfirmationModal = false;
    this.exitEditBucketTaskForm();
  }

  popDeleteBucketTaskConfirmationModal() {    
    this.bucketTaskDeleteConfirmationModal = !this.bucketTaskDeleteConfirmationModal;
  }

  exitDeleteBucketTaskConfirmationModal() {
    this.bucketTaskDeleteConfirmationModal = false;
    this.exitEditBucketTaskConfirmationModal()
  }

  MaxAmountOfTasksReachedWarningModal = false;

  popNewBucketTaskMaxAmountOfTasksReachedWarning() {
    this.MaxAmountOfTasksReachedWarningModal = true;
  }

  exitNewBucketTaskMaxAmountOfTasksReachedWarning() {
    this.MaxAmountOfTasksReachedWarningModal = false;
  }
}
