import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BucketComponent } from './buckets/bucket/bucket.component';
import { BucketsComponent } from './buckets/buckets.component';
import { BucketNewComponent } from './buckets/bucket-new/bucket-new.component';
import { BucketEditComponent } from './buckets/bucket-edit/bucket-edit.component';
import { AuthGuard } from './services/auth/auth.guard';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'buckets', component: BucketsComponent, canActivate: [AuthGuard] },
  { path: 'bucket-details/:id', component: BucketComponent },
  { path: 'bucketnew', component: BucketNewComponent },
  { path: 'bucket-edit/:id', component: BucketEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
