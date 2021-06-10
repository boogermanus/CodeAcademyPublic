import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CatalogViewComponent } from './views/catalog/catalog.component';
import { HomeViewComponent } from './views/home/home.component';
import { LoginViewComponent } from './views/login/login.component';


const routes: Routes = [
  { path: 'catalog', component: CatalogViewComponent },
  { path: 'catalog/:catalogId', component: CatalogViewComponent},
  { path: 'home', component: HomeViewComponent },
  { path: 'login', component: LoginViewComponent },
  { path: '**', component: HomeViewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
