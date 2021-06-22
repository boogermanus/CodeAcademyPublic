import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }
  url = 'https://jsonplaceholder.typicode.com/';

  async get(path) {
    return await this.httpClient.get<any[]>(this.url + path).toPromise();
  }

  async post(path, data, options){
    return await this.httpClient.post<any>(this.url + path, data, options).toPromise();
  }

}
