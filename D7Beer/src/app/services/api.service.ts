import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IBeer } from '../models/ibeer';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private BEERS_URL = 'https://api.punkapi.com/v2/beers';

  constructor(private httpService: HttpClient) {

   }

   async get(params?: HttpParams): Promise<IBeer[]> {
    return this.httpService.get<IBeer[]>(this.BEERS_URL,
      {headers: null, params}).toPromise();
   }
}
