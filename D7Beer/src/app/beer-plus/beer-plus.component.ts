import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { IBeer } from '../models/ibeer';
import { MatTableDataSource } from '@angular/material/table';
import { DataService } from '../services/data.service';
import { IColumn } from '../models/icolumn';

@Component({
  selector: 'app-beer-plus',
  templateUrl: './beer-plus.component.html',
  styleUrls: ['./beer-plus.component.css']
})
export class BeerPlusComponent implements OnInit {

  displayedColumns: string[] = [
    'id',
    'name',
    'tagline',
    'image_url',
    'abv',
  ];

  count = 25;
  columns: IColumn[] = [
    {columnDef: 'id', header: 'Id', cell: (element: any) => element[this.displayedColumns[0]]},
    {columnDef: 'name', header: 'Name', cell: (element: any) => element[this.displayedColumns[1]]},
    {columnDef: 'tagline', header: 'Tagline', cell: (element: any) => element[this.displayedColumns[2]]},
    {columnDef: 'abv', header: 'A.B.V.', cell: (element: any) => element[this.displayedColumns[4]]}
  ];

  dataSource: MatTableDataSource<IBeer>;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  constructor(private dataService: DataService) { }
  async ngOnInit() {
    const data = await this.dataService.getBeers();

    this.dataSource = new MatTableDataSource(data);
    this.dataSource = this.setupDataSource(this.dataSource);

  }

  setupDataSource(dataSource: MatTableDataSource<IBeer>): MatTableDataSource<IBeer> {
    dataSource.sort = this.sort;
    dataSource.paginator = this.paginator;

    return dataSource;
  }

  async getNewBeer() {
    // because count is initially set to 25 this will simply reload 25 beers
    // better to use ++this.count to increment first!
    this.dataSource = new MatTableDataSource(await this.dataService.getBeersByCount(++this.count));
    this.dataSource = this.setupDataSource(this.dataSource);
  }

}
