import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { IProduct } from '../interfaces/iproduct';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {

  @Output() productAdded: EventEmitter<IProduct> = new EventEmitter<IProduct>();
  newProduct: IProduct = {
    name: '',
    description: '',
    price: 0
  };

  constructor(private productService: ProductService) { }

  ngOnInit() {
  }

  add() {
    console.log(this.newProduct);
    this.productAdded.emit(this.newProduct);
    this.productService.addProduct(this.newProduct);
    this.resetProduct();
  }

  resetProduct() {
    this.newProduct = {
      name: '',
      description: '',
      price: 0
    };
  }

}
