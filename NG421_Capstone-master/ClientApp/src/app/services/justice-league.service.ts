import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JusticeLeagueMember } from '../interfaces/justice-league-member';

@Injectable({
  providedIn: 'root'
})
export class JusticeLeagueService {

  constructor(private httpService: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  async getMembers() {
    return await this.httpService.get<JusticeLeagueMember[]>(`${this.baseUrl}justiceleague`).toPromise();
  }

  async addMember(newMember: JusticeLeagueMember) {
    return await this.httpService.post<JusticeLeagueMember>(`${this.baseUrl}justiceleague`, newMember).toPromise();
  }
}
