import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BucketComponent } from './buckets/bucket/bucket.component';
import { BucketsComponent } from './buckets/buckets.component';
import { BucketNewComponent } from './buckets/bucket-new/bucket-new.component';
import { BucketEditComponent } from './buckets/bucket-edit/bucket-edit.component';
import { AuthGuard } from './services/auth/auth.guard';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'buckets', component: BucketsComponent, canActivate: [AuthGuard] },
  { path: 'bucket-details/:id', component: BucketComponent, canActivate: [AuthGuard] },
  { path: 'bucketnew', component: BucketNewComponent, canActivate: [AuthGuard] },
  { path: 'bucket-edit/:id', component: BucketEditComponent, canActivate: [AuthGuard] },
  { path: 'register', component: RegisterComponent },
  { path: '**', redirectTo: '/login' } // Wildcard route to catch all other routes and redirect to login
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
