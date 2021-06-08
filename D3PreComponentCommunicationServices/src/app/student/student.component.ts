import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  @Input() student: any = {};

  constructor() { }

  ngOnInit(): void {
  }

}
