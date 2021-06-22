import { Component, OnInit } from '@angular/core';
import { TodoService } from '../services/todo.service';

@Component({
  selector: 'app-create-todo',
  templateUrl: './create-todo.component.html',
  styleUrls: ['./create-todo.component.css']
})
export class CreateTodoComponent implements OnInit {

  todoTitle = '';
  constructor(private service: TodoService) { }

  ngOnInit() {
  }

  addTodo(): void {
    this.service.addTodo(this.todoTitle);
    this.todoTitle = '';
  }

}
