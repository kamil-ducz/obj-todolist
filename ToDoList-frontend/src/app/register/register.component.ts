import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Bucket } from '../models/bucket.model';
import { UserService } from '../services/auth/user.service';
import { User } from '../models/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(
    private userService: UserService, 
    private toastr: ToastrService
    ) { }

  ngOnInit(): void {
  }

  registerUserFormGroup = new FormGroup({
    firstName: new FormControl('', [
      Validators.maxLength(50),
    ]),
    lastName: new FormControl('', [
      Validators.maxLength(50),
    ]),
    username: new FormControl('', [
      Validators.required,
      Validators.min(5),
      Validators.max(15),      
    ]),
    email: new FormControl('', [
      Validators.minLength(5),
      Validators.maxLength(100),
      Validators.email
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.min(5),
      Validators.max(15),
    ])
  });

  onSubmitNewUser(newUser: User) {
    this.userService.postUser(newUser).subscribe(
      () => {
        this.toastr.success(`User ${newUser.username} added successfully.`);
      }
    );
  }
}
