import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { BucketComponent } from './bucket/bucket.component';
import { BucketsComponent } from './buckets/buckets.component';
import { HttpClientModule } from '@angular/common/http';
import { AssigneesComponent } from './assignees/assignees.component';
import { BucketNewComponent } from './buckets/bucket-new/bucket-new.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BucketEditComponent } from './buckets/bucket-edit/bucket-edit.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BucketComponent,
    BucketsComponent,
    AssigneesComponent,
    BucketNewComponent,
    BucketEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    MatFormFieldModule,
    MatInputModule, 
    MatAutocompleteModule   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
