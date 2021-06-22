import { Injectable } from '@angular/core';
import { JusticeLeagueMember } from '../interfaces/justice-league-member';
import { JUSTICE_LEAGUE_MEMBERS } from '../data/justice-league-data';

@Injectable({
  providedIn: 'root'
})
export class JusticeLeagueService {

  members: JusticeLeagueMember[] = [];

  constructor() {
    this.members = JUSTICE_LEAGUE_MEMBERS;
  }

  getMembers(): JusticeLeagueMember[] {
    return this.members;
  }
}
