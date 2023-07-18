import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { BucketService } from '../../services/bucket-service';
import { Bucket } from '../../models/bucket.model';
import { BucketTaskService } from '../../services/buckettask-service';
import { FormControl, FormGroup, UntypedFormBuilder, Validators } from '@angular/forms';
import { BucketTask } from '../../models/bucket-task.model';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';
import { DictionaryService } from '../../services/dictionary-service';
import { BucketTaskState } from '../../models/bucket-task-state.model';
import { BucketTaskPriority } from '../../models/bucket-task-priority.model';
import { BucketCategory } from '../../models/bucket-category.model';
import { BucketColor } from '../../models/bucket-color.model';
import { Assignee } from '../../models/assignee.model';
import { AssigneeService } from '../../services/assignee-service';

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
  filteredAssignees: Assignee[];
  showAssignees = false;
  assignee = new FormControl();

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.currentBucketId = +params['id'];
      }
    );
    this.refreshCurrentBucketBucketTasksComponents();
  }
  
  async refreshCurrentBucketBucketTasksComponents() {
    await this.fetchBucketCategories();
    this.fetchCurrentBucket();
    this.fetchBucketTasks();
    this.fetchBucketTasksStates();
    this.fetchBucketTaskPriorities();
    this.fetchAssigness();
  }

  fetchCurrentBucket() {
    this.bucketService.getBucket(environment.bucketEndpoint+this.currentBucketId).subscribe(
      (response: Bucket) => {
        this.currentBucket = response;
        this.currentBucketCategoryName = this.bucketCategories.find(bcat => bcat.id === this.currentBucket.bucketCategoryId).name;
      }
    );
  }

  async fetchBucketCategories() {
    this.dictionaryService.getBucketCategories(environment.bucketCategoryEndpoint).subscribe(
      (response: BucketCategory[]) => {
        this.bucketCategories = response;
      }
    );
  }

  fetchBucketTasks() {
    this.bucketService.getBucketTasks(environment.buckeTasksForBucketEndpoint+this.currentBucketId).subscribe(
      (response: BucketTask[]) => {
        this.currentBucketBucketTasks = response;
        this.bucketTasksToDo = this.currentBucketBucketTasks.filter(element => element.bucketTaskStateId == 1);
        this.bucketTasksInProgress = this.currentBucketBucketTasks.filter(element => element.bucketTaskStateId == 2);
        this.bucketTasksDone = this.currentBucketBucketTasks.filter(element => element.bucketTaskStateId == 3);
        this.bucketTasksCancelled = this.currentBucketBucketTasks.filter(element => element.bucketTaskStateId == 4);
      }
    );
  }

  fetchBucketTasksStates() {
    this.dictionaryService.getBucketTaskStates(environment.bucketTaskStatesEndpoint).subscribe(
      (response: BucketTaskState[]) => {
        this.bucketTaskStates = response;
      }
    );
  }

  fetchBucketTaskPriorities() {
    this.dictionaryService.getBucketTaskPriorities(environment.bucketTaskPrioritiesEndoint).subscribe(
      (response: BucketTaskPriority[]) => {
        this.bucketTaskPriorities = response;
      }
    );
  }

  fetchAssigness() {
    this.assigneeService.getAssignees(environment.assigneeEndpoint).subscribe(
      (response: Assignee[]) => {
        this.assignees = response;
      }
    );
  }

  toggleShowAssignees() {
    this.filteredAssignees = this.assignees;
    this.showAssignees = !this.showAssignees;
  }

  selectAssignee(assignee: Assignee) {
    this.bucketTaskFormGroup.patchValue({ assignee:assignee.name });
    this.showAssignees = false;
  }

  filterAssignees(value: string) {
    this.filteredAssignees = this.assignees.filter(assignee => assignee.name.toLowerCase().includes(value.toLowerCase()));
  }

  onAssigneeInputChange(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    const value = inputElement.value;
    this.filterAssignees(value);
  }

  findAssigneeById(assignees: Assignee[], id: number): string {
    if (id) {
      return assignees.find(a => a.id == id).name;
    }
    else {
      return null;
    }
  }

  async findAssigneeByName(assignees: Assignee[], name: string): Promise<number> {
    const foundAssignee = assignees.find(a => a.name === name);
    if (!foundAssignee && name === '' || foundAssignee == null && name === '') {
      return null;
    }
    if (foundAssignee) {
        return assignees.find(a => a.name === name).id;
      }
    else {
        const newAssigneeId = await this.createNewAdHocAssignee(name);
        return newAssigneeId;
    }
  }

  createNewAdHocAssignee(name:string): Promise<number> {
    var newAssignee: Assignee = {
      id: null,
      name: name
    }
    return new Promise<number>((resolve) => {
      this.assigneeService.postAssignee(environment.assigneeEndpoint, newAssignee).subscribe(
        (response: Assignee) => {
          this.toastr.success("Ad hoc assignee added: " + name);
          resolve(response.id);
        },
      );
    });
  }

  incrementBucketTaskState(bucketTask: BucketTask) {
    event.stopPropagation();
    const incrementedBucketTask = bucketTask;
    if (incrementedBucketTask.bucketTaskStateId === 4) {
      incrementedBucketTask.bucketTaskStateId = 1;
    }
    else {
      incrementedBucketTask.bucketTaskStateId++;
    }
    this.bucketTaskService.putBucketTask(environment.bucketTaskEndpoint + bucketTask.id, incrementedBucketTask).subscribe(
      () => {
        this.toastr.success("Increased bucket task state. Congratulations on good work friend!");
        this.refreshCurrentBucketBucketTasksComponents();
      }
    )
  }

  newBucketTaskToCreate: BucketTask;
  addNewBucketTaskFormGroup: FormGroup;
  editNewBucketTaskFormGroup: FormGroup;
  bucketTaskFormGroup: FormGroup;

  initializeBucketTaskForm() {
    this.bucketTaskFormGroup = new FormGroup({
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
      assignee: new FormControl('')
    });

    if (this.showEditBucketTaskForm === true)
    {
      const bucketTaskName = this.currentBucketTask.name;
      const bucketTaskDescription = this.currentBucketTask.description;   

      const bucketTaskState = this.bucketTaskStates.find(bts => bts.id === this.currentBucketTask.bucketTaskStateId).name;
      const bucketTaskPriority = this.bucketTaskPriorities.find(btps => btps.id === this.currentBucketTask.bucketTaskPriorityId).name;  
      const assigneeName = this.findAssigneeById(this.assignees, this.currentBucketTask.assigneeId);
      this.bucketTaskFormGroup.patchValue({ name: bucketTaskName });
      this.bucketTaskFormGroup.patchValue({ description: bucketTaskDescription });
      this.bucketTaskFormGroup.patchValue({ bucketTaskState: bucketTaskState });
      this.bucketTaskFormGroup.patchValue({ bucketTaskPriority: bucketTaskPriority });
      this.bucketTaskFormGroup.patchValue({ assignee: assigneeName });
    }
  }

  async onSubmitBucketTask(newBucketTask: BucketTask) {
    this.currentBucketTask = newBucketTask;
    this.currentBucketTask.bucketTaskStateId = this.bucketTaskStates.find(bs => bs.name === this.currentBucketTask.bucketTaskState).id;
    this.currentBucketTask.bucketTaskPriorityId = this.bucketTaskPriorities.find(bp => bp.name === this.currentBucketTask.bucketTaskPriority).id;
    this.currentBucketTask.assigneeId = await this.findAssigneeByName(this.assignees, this.bucketTaskFormGroup.value.assignee);
    console.log("this.currentBucketTask.assigneeId = " + this.currentBucketTask.assigneeId);
    this.currentBucketTask.bucketTaskState = null;
    this.currentBucketTask.bucketTaskPriority = null;
    this.currentBucketTask.bucketId = this.currentBucketId;    

    if (this.currentBucketBucketTasks.length < this.currentBucket.maxAmountOfTasks)
    {
      this.bucketTaskService.postBucketTask(environment.bucketTaskEndpoint, this.currentBucketTask).subscribe(
        (response) => {
          this.toastr.success(`Bucket task ${this.currentBucketTask.name} created successfully`);
        }
      );
    }
    else 
    {
      this.popNewBucketTaskMaxAmountOfTasksReachedWarning();
      return null;
    }
  }

  async onSubmitEditBucketTask(newBucketTask: BucketTask) {
    this.currentBucketTask = this.bucketTaskFormGroup.value;
    this.currentBucketTask.bucketId = this.currentBucketId;
    this.currentBucketTask.bucketTaskStateId = this.bucketTaskStates.find(bts => bts.name === newBucketTask.bucketTaskState).id;
    this.currentBucketTask.bucketTaskPriorityId = this.bucketTaskPriorities.find(btps => btps.name === newBucketTask.bucketTaskPriority).id;
    this.currentBucketTask.assigneeId = await this.findAssigneeByName(this.assignees, this.bucketTaskFormGroup.value.assignee);
    console.log("this.currentBucketTask.assigneeId = " + this.currentBucketTask.assigneeId);
    this.currentBucketTask.bucketTaskState = null;
    this.currentBucketTask.bucketTaskPriority = null;

    this.bucketTaskService.putBucketTask(environment.bucketTaskEndpoint+this.bucketTaskForEditSaveId, this.currentBucketTask).subscribe(
      (response: any) => {
        this.toastr.success(`Bucket task ${this.currentBucketTask.name} changes saved successfully.`);
      }
    );
  }

  removeBucket(id: any) {
    this.bucketService.deleteBucket(environment.bucketEndpoint+id).subscribe(
        (response: any) => {
          this.toastr.success(`Bucket ${this.currentBucket.name} deleted successfully.`);
          this.router.navigate(['/buckets']);
        }
    );
  }

  removeBucketTask(bucketTaskId: number) {
    this.bucketTaskService.deleteBucketTask(environment.bucketTaskEndpoint+bucketTaskId).subscribe(
      (response: any) => {
        this.fetchBucketTasks();
        this.toastr.success(`Bucket task ${this.currentBucketTask.name} deleted successfully.`);
        this.exitDeleteBucketTaskConfirmationModal();
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
    this.initializeBucketTaskForm();
  }

  exitNewBucketTaskForm() {
    this.showNewBucketTaskForm = false;
    this.showAssignees = false;
    this.refreshCurrentBucketBucketTasksComponents();
  }

  exitNewBucketTaskConfirmationModal() {
    this.exitNewBucketTaskForm();
  }

  popEditBucketTaskForm(bucketTaskId: number) {
    this.showEditBucketTaskForm = !this.showEditBucketTaskForm;
    this.currentBucketTask = this.currentBucketBucketTasks.find(element => element.id == bucketTaskId);
    this.bucketTaskForEditSaveId = bucketTaskId;
    this.initializeBucketTaskForm();
  }

  exitEditBucketTaskForm() {
    this.showEditBucketTaskForm = false;
    this.showAssignees = false;
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
