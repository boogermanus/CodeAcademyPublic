import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  API_URL = 'https://ce-authenticated-backend.herokuapp.com/';
  token: string;
  constructor(private httpService: HttpClient) { }

  async get(path: string) {
    return await this.httpService.get<any[]>(this.API_URL + path).toPromise();
  }

  async post(path: string, data: any) {
    const headers: HttpHeaders = new HttpHeaders(
      {'Content-Type': 'application/json'},
    );

    return await this.httpService.post<any>(this.API_URL + path, data, {headers}).toPromise();
  }
}
