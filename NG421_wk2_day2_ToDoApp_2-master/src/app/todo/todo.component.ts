import { Component, OnInit, Input } from '@angular/core';
import { ITodo } from '../interfaces/ITodo';
import { TodoService } from '../services/todo.service';
import { ModalService } from '../services/modal.service';
import { ModalConstants } from '../modal/modal.constants';
import { MatDialog } from '@angular/material/dialog';
import { MaterialModelComponent } from '../material-model/material-model.component';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {

  @Input()
  todo: ITodo;

  constructor(
    private service: TodoService,
    private modalService: ModalService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
  }

  async deleteTodo() {

    const result = await this.modalService.show();

    if (result === ModalConstants.YES) {
      this.service.deleteTodo(this.todo);
    }
  }

  deleteTodoMaterial() {
    const dialogRef = this.dialog.open(MaterialModelComponent, { width: '250px' });

    dialogRef.afterClosed().subscribe(result => {
      if (result === ModalConstants.YES) {
        this.service.deleteTodo(this.todo);
      }
    });
  }
}
