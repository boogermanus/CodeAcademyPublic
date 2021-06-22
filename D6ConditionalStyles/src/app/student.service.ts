import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  students = [{
    id: 1,
    name: 'Leanne Graham',
    firstName: 'Leanne',
    lastName: 'Graham',
    image: 'https://i.picsum.photos/id/11/200/300.jpg',
    grade: 'A'
  },
  {
    id: 2,
    firstName: 'Ervin',
    lastName: 'Howell',
    image: 'https://i.picsum.photos/id/2/200/300.jpg', name: 'Ervin Howell', grade: 'B'
  },
  {
    id: 3, firstName: 'Clementine',
    lastName: 'Bauch',
    image: 'https://i.picsum.photos/id/4/200/300.jpg', name: 'Clementine Bauch', grade: 'C'
  },
  {
    id: 5, firstName: 'Jon',
    lastName: 'Smith', image: 'https://i.picsum.photos/id/5/200/300.jpg', name: 'Jon Smith', grade: 'D'
  },
  {
    id: 4, firstName: 'Patricia',
    lastName: 'Lebsack',
    image: 'https://i.picsum.photos/id/65/200/300.jpg', name: 'Patricia Lebsack', grade: 'F', message: 'You are failing'
  },
];

  constructor() { }

  createStudent(student: any): void {
    this.students.push(student);
  }

  getStudents(): any[] {
    return this.students;
  }
}
