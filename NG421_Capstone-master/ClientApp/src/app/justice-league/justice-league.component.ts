import { Component, OnInit } from '@angular/core';
import { JusticeLeagueService } from '../services/justice-league.service';
import { JusticeLeagueMember } from '../interfaces/justice-league-member';

@Component({
  selector: 'app-justice-league',
  templateUrl: './justice-league.component.html',
  styleUrls: ['./justice-league.component.css']
})
export class JusticeLeagueComponent implements OnInit {

  public justiceLeagueMembers: JusticeLeagueMember[];
  public newMember: JusticeLeagueMember = {
    id: undefined,
    name: '',
    alias: '',
    age: 1,
    memberSince: null,
    isActiveMember: true
  };

  constructor(private justiceLeagueService: JusticeLeagueService) { }

  async ngOnInit() {
    this.justiceLeagueMembers = await this.justiceLeagueService.getMembers();
  }

  async addMember() {
    const newMember = await this.justiceLeagueService.addMember(this.newMember);
    this.justiceLeagueMembers.push(newMember);
    console.log(this.newMember);
  }

}
