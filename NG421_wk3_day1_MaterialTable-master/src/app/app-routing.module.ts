import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';
import { TableComponent } from './table/table.component';
import { FlexTableComponent } from './flex-table/flex-table.component';

const routes: Route[] = [
  {path: '', component: TableComponent},
  {path: 'flex', component: FlexTableComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
