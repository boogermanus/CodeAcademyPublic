import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-material-model',
  templateUrl: './material-model.component.html',
  styleUrls: ['./material-model.component.css']
})
export class MaterialModelComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<MaterialModelComponent>) { }

  ngOnInit() {
  }

  close() {
    this.dialogRef.close();
  }

}
