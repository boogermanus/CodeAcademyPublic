import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  students: any[] = [];
  constructor() { }

  ngOnInit() {
  // pushing into this array
   this.students = [];
  }

  newStudentCreate(student: any): void {
    this.students.push(student);
  }

}
