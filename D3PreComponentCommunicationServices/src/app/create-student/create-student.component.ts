import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { StudentService } from '../student.service';

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

  // no! This is not how DI works!
  // studentService = new StudentService()
  constructor(private studentService: StudentService) {}

  ngOnInit(): void {
  }

  onSave(event: any) {

    this.studentService.addStudent(this.newStudent);
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
