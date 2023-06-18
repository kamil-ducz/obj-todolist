import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BucketComponent } from './bucket/bucket.component';
import { BucketsComponent } from './buckets/buckets.component';

const routes: Routes = [
  { path: '', component: BucketsComponent },
  { path: 'bucket', component: BucketComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
