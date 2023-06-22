import { Component, OnInit } from '@angular/core';
import { BucketService } from '../services/bucket-service';

@Component({
  selector: 'app-buckets',
  templateUrl: './buckets.component.html',
  styleUrls: ['./buckets.component.css']
})
export class BucketsComponent implements OnInit {

  constructor(private bucketService: BucketService) { }

  bucketsData: any;

  ngOnInit() {
    this.bucketService.getBuckets().subscribe(
      (response: any) => {
        this.bucketsData = response;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  RemoveBucket(id: any) {
    this.bucketService.deleteBucket(id).subscribe(
        (response: any) => {
          this.showModal = !this.showModal;
          this.ngOnInit();
        },
        (error: any) => {
          console.error(error);
        }
    );
  }

  elementToRemove: any;

  showModal = false;

  findElementToRemoveById(id: number) {
    const foundElement = this.bucketsData.find(element => element.id == id);
    if(foundElement)
    {
      return foundElement;
    }
    else
    {
      return;
    }
  }

  toggleDeleteModal(i: number, e: Event) {
    this.elementToRemove = this.findElementToRemoveById(i);
    this.showModal = !this.showModal;
    event.stopPropagation();
  }

  exitDeleteModal() {
    this.showModal = !this.showModal;
  }
} 