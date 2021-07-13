import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-teacher',
    templateUrl: './teacher.component.html'
})
export class TeacherComponent implements OnInit {
    public teachers: Teacher[];
    public newTeacher: Teacher = {firstName: '', lastName: ''};

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    }
    async ngOnInit() {
        this.teachers = await this.http.get<Teacher[]>(this.baseUrl + 'teacher').toPromise();
    }
    async save() {
        await this.http.post<Teacher[]>(this.baseUrl + 'teacher', this.newTeacher).toPromise();
        this.newTeacher = { firstName: '', lastName: '' };
        this.teachers = await this.http.get<Teacher[]>(this.baseUrl + 'teacher').toPromise();
    }


}

interface Teacher {
    firstName: string;
    lastName: string;
}
