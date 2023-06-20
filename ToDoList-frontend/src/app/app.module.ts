import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { BucketComponent } from './bucket/bucket.component';
import { BucketsComponent } from './buckets/buckets.component';
import { HttpClientModule } from '@angular/common/http';
import { BucketTasksComponent } from './bucket-tasks/bucket-tasks.component';
import { AssigneesComponent } from './assignees/assignees.component';
import { BucketNewComponent } from './buckets/bucket-new/bucket-new.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BucketComponent,
    BucketsComponent,
    BucketTasksComponent,
    AssigneesComponent,
    BucketNewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
