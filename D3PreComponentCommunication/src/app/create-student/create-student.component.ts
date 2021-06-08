import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-create-student',
  templateUrl: './create-student.component.html',
  styleUrls: ['./create-student.component.css']
})
export class CreateStudentComponent implements OnInit {
  newStudent = {
    firstName: '',
    lastName: '',
    grade: '',
    address: '',
    image: ''
  };

  @Output() newStudentCreated = new EventEmitter<object>();

  constructor() {}

  ngOnInit(): void {
  }

  onSave(event: any) {
    // a new student was created here
    this.newStudentCreated.emit(this.newStudent);
    this.newStudent = {
      firstName: '',
      lastName: '',
      grade: '',
      address: '',
      image: ''
    };
    console.log(this.newStudent);
  }
}
