import { Component, OnInit } from '@angular/core';
import { NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ModalConstants } from './modal.constants';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  modalInstance: NgbModalRef;
  constructor() { }

  ngOnInit() {
  }

  close() {
    this.modalInstance.close(ModalConstants.NO);
  }

  yes() {
    this.modalInstance.close(ModalConstants.YES);
  }

}
