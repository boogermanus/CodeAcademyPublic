import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatTable } from '@angular/material/table';
import { IBeer } from '../models/ibeer';
import { MatSort } from '@angular/material/sort';
import { DataService } from '../services/data.service';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-beer',
  templateUrl: './beer.component.html',
  styleUrls: ['./beer.component.css']
})
export class BeerComponent implements OnInit {

  displayedColumns: string[] = [
    'id',
    'name',
    'tagline',
    'image_url',
    'abv',
  ];

  dataSource: MatTableDataSource<IBeer>;
  @ViewChild(MatSort, {static: true})sort: MatSort;
  @ViewChild(MatPaginator, {static: true})paginator: MatPaginator;
  count = 25;
  constructor(private dataService: DataService) { }

  async ngOnInit() {
    const data = await this.dataService.getBeers();

    this.dataSource = new MatTableDataSource(data);
    this.dataSource = this.setupDataSource(this.dataSource);

  }

  async getNewBeer() {
    // because count is initially set to 25 this will simply reload 25 beers
    // better to use ++this.count to increment first!
    this.dataSource = new MatTableDataSource(await this.dataService.getBeersByCount(++this.count));
    this.dataSource = this.setupDataSource(this.dataSource);
  }

  setupDataSource(dataSource: MatTableDataSource<IBeer>): MatTableDataSource<IBeer> {
    dataSource.sort = this.sort;
    dataSource.paginator = this.paginator;

    return dataSource;
  }

}
