import { Component, OnInit } from '@angular/core';
import { ApiService } from './api.service';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  users: any[];

  constructor(private apiService: ApiService) {}

  async ngOnInit(){
    const data = await this.apiService.get('users');

    console.log(data);
    this.users = data;
  }

  async createUser(){
    const user =  {
      name: 'Leanne Graham',
      username: 'Bret',
      email: 'Sincere@april.biz',
      phone: '1-770-736-8031 x56442',
      website: 'hildegard.org'
    };
    const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json'
        })
    };

    const data = await this.apiService.post('users' , user, httpOptions);
    this.users = await this.apiService.get('users');
  }

}
