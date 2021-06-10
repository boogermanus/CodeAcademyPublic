import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  students = [ {
    firstName: 'Bob',
    lastName: 'Stanley',
    address: '100 main st Austin, TX 78741',
    image: 'https://picsum.photos/200/300/?random',
    theNumber: Math.random()
  }];

  constructor() { }

  createStudent(student) {
    this.students.push(student);
  }

  getStudents(){
    return this.students;
  }
}
