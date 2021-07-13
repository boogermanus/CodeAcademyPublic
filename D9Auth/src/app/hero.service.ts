import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class HeroService {

  constructor(private apiService: ApiService) { }

  async addHero(name: string) {
    await this.apiService.post('heroes', {
      name
    });
  }

  async getHeroes() {
    return await this.apiService.get('heroes');
  }
}
