import { Injectable } from '@angular/core';

import { ApiService } from './api.service';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private apiService: ApiService) { }

  async getBeers() {
    return await this.apiService.get();
  }

  async getBeersByCount(count: number) {
    return await this.apiService.get(new HttpParams()
    .append('per_page', count.toString()));
  }

}
