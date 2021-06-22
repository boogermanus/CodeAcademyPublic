import { Component, OnInit } from '@angular/core';
import { TodoService } from '../services/todo.service';
import { ITodo } from '../interfaces/ITodo';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

  todoList: ITodo[] = [];
  constructor(private service: TodoService) { }

  ngOnInit() {
    this.todoList = this.service.getTodos();
  }

}
