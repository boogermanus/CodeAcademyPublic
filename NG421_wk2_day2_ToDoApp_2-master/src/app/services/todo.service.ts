import { Injectable } from '@angular/core';
import { ITodo } from '../interfaces/ITodo';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  todoList: ITodo[] = [
    { id: 1, title: 'Install Angular CLI', isDone: false },
  ];
  todoId = 0;

  constructor() { }

  addTodo(title: string): void {
    this.todoList.push({
      id: this.todoId++,
      title,
      isDone: false
    });
  }

  deleteTodo(todo: ITodo) {
    const index = this.todoList.findIndex(todoItem => todoItem === todo);
    this.todoList.splice(index, 1);
  }

  getTodos(): ITodo[] {
    return this.todoList;
  }
}
