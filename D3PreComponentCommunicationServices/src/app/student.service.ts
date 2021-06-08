import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  students: any[] = [];
  constructor() { }

  getStudents(): any[] {
    return this.students;
  }

  addStudent(student: any): void {
    this.students.push(student);
  }
}
