import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {
  constructor(
    
  ) { }

  private loading: boolean = false;

  setLoading(loading: boolean) {
    this.loading = loading;
  }

  getLoading() {
    return this.loading;
  }
}
