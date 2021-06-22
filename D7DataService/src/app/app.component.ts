import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'D5DataService';
  users: any[];

  constructor(private dataService: DataService) {}

  async ngOnInit(){
    const data = await this.dataService.getAll();
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
    const data = await this.dataService.save(user);
  }
}
