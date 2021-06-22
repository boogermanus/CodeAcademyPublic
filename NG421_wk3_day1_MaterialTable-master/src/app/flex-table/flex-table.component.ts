import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { JusticeLeagueMember } from '../interfaces/justice-league-member';
import { JusticeLeagueService } from '../services/justice-league.service';

@Component({
  selector: 'app-flex-table',
  templateUrl: './flex-table.component.html',
  styleUrls: ['./flex-table.component.css']
})
export class FlexTableComponent implements OnInit {
  displayedColumns: string[] = ['name', 'alias', 'age', 'currentMember', 'memberSince', 'powers'];
  dataSource: MatTableDataSource<JusticeLeagueMember>;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true})paginator: MatPaginator;

  constructor(private justiceLeagueService: JusticeLeagueService) {

  }

  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.justiceLeagueService.getMembers());
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(filter: string) {
    this.dataSource.filter = filter.trim().toLowerCase();
  }
}
