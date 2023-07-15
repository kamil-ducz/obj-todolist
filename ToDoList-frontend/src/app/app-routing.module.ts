import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BucketComponent } from './buckets/bucket/bucket.component';
import { BucketsComponent } from './buckets/buckets.component';
import { BucketNewComponent } from './buckets/bucket-new/bucket-new.component';
import { BucketEditComponent } from './buckets/bucket-edit/bucket-edit.component';

const routes: Routes = [
  { path: '', redirectTo: '/buckets', pathMatch: 'full' },
  { path: 'buckets', component: BucketsComponent },
  { path: 'bucket-details/:id', component: BucketComponent },
  { path: 'bucketnew', component: BucketNewComponent },
  { path: 'bucket-edit/:id', component: BucketEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
