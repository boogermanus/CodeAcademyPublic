import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CatalogViewComponent } from './views/catalog/catalog.component';
import { HomeViewComponent } from './views/home/home.component';
import { LoginViewComponent } from './views/login/login.component';


@NgModule({
  declarations: [
    AppComponent,
    CatalogViewComponent,
    HomeViewComponent,
    LoginViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
