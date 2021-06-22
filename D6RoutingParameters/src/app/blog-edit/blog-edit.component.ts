import { Component, OnInit } from '@angular/core';
import { NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-blog-edit',
  templateUrl: './blog-edit.component.html',
  styleUrls: ['./blog-edit.component.css']
})
export class BlogEditComponent implements OnInit {

  modalInstance: NgbModalRef;
  description = '';
  blog: any;

  constructor() { }

  ngOnInit(): void {
  }

  yes(): void {
    this.modalInstance.close(this.description);
  }

}
