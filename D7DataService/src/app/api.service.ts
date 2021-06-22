import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  url = 'https://jsonplaceholder.typicode.com/';

  constructor(private httpClient: HttpClient) { }

  async get(path): Promise<any[]> {
    return await this.httpClient.get<any[]>(this.url + path).toPromise();
  }
  async post(path, data) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return await this.httpClient.post<any>(this.url + path, data, httpOptions).toPromise();
  }
}
