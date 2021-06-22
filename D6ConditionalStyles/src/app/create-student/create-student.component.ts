import { Component, OnInit } from '@angular/core';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-create-student',
  templateUrl: './create-student.component.html',
  styleUrls: ['./create-student.component.css']
})
export class CreateStudentComponent implements OnInit {

  public newStudent = {
    firstName: '',
    lastName: '',
    grade: '',
    address: '',
    image: ''
  };

  constructor(private studentService: StudentService) { }

  ngOnInit(): void {
  }

  onSave(event: any): void {
    this.studentService.createStudent(this.newStudent);
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
