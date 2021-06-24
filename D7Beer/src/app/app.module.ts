import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { BeerComponent } from './beer/beer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { RouterModule, Route } from '@angular/router';
import { BeerPlusComponent } from './beer-plus/beer-plus.component';

const routes: Route[] = [
  { path: 'beerplus', component: BeerPlusComponent},
  { path: 'beers', component: BeerComponent},
  { path: '**', component: BeerComponent}
];
@NgModule({
  declarations: [
    AppComponent,
    BeerComponent,
    BeerPlusComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatTableModule,
    MatSortModule,
    MatButtonModule,
    MatPaginatorModule,
    RouterModule.forRoot(routes),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
