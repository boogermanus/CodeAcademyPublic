import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReactiveComponent } from './reactive/reactive.component';
import { TemplateComponent } from './template/template.component';


const routes: Routes = [
  {path: 'template', component: TemplateComponent},
  {path: 'reactive', component: ReactiveComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
