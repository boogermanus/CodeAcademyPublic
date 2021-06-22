import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private apiService: ApiService) { }

  async getAll() {
    const data = await this.apiService.get('users');
    return data;
  }
  async save(user: any) {
    const data = await this.apiService.post('users', user);
    return data;
  }
}
