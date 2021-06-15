import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IProduct } from '../model/IProduct';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  @Input()
  product: IProduct;

  @Output()
  productAdded: EventEmitter<IProduct> = new EventEmitter<IProduct>();

  constructor() { }

  ngOnInit(): void {
  }

  addToCart(): void {
    this.productAdded.emit(this.product);
  }
}
