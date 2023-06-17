import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { BucketComponent } from './bucket/bucket.component';
import { BucketsComponent } from './buckets/buckets.component';
import { HttpClientModule } from '@angular/common/http';
import { BucketTasksComponent } from './bucket-tasks/bucket-tasks.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    StatisticsComponent,
    BucketComponent,
    BucketsComponent,
    BucketTasksComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
