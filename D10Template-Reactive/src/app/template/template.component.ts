import { Component, OnInit } from '@angular/core';
import { IUser } from '../models/iuser';

@Component({
  selector: 'app-template',
  templateUrl: './template.component.html',
  styleUrls: ['./template.component.css']
})
export class TemplateComponent implements OnInit {

  user: IUser = {
    email: '',
    password: '',
    name: '',
    confirmPassword: '',
  };

  constructor() { }

  ngOnInit(): void {
  }

  submit(): void {
    console.log(this.user);
  }
}
