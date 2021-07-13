import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { StudentsComponent } from './students/students.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { TeacherComponent } from './teacher/teacher.component';
import { JusticeLeagueComponent } from './justice-league/justice-league.component';
import { JusticeLeagueService } from './services/justice-league.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    StudentsComponent,
    TeacherComponent,
    JusticeLeagueComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      // { path: 'counter', component: CounterComponent },
      // { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      // { path: 'students', component: StudentsComponent, canActivate: [AuthorizeGuard] },
      // { path: 'teachers', component: TeacherComponent, canActivate: [AuthorizeGuard] },
      { path: 'justiceleaguemembers', component: JusticeLeagueComponent, canActivate: [AuthorizeGuard]}
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    JusticeLeagueService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
