import { Injectable } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';

@Injectable({
  providedIn: 'root'
})
export class ModalService {

  constructor(
    private modalService: NgbModal
  ) { }

  async show(): Promise<any> {
    const model = this.modalService.open(ModalComponent);

    // modalComponent == ModalComponent
    const modalComponent: ModalComponent = model.componentInstance;
    modalComponent.modalInstance = model;

    try {
      return await model.result;
    } catch (error) {
      // console.log(error);
    }

  }
}
