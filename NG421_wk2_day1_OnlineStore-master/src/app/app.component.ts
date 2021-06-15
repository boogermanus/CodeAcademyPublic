import { Component, OnInit } from '@angular/core';
import {ProductService} from './product.service';
import { IProduct } from './model/IProduct';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  products: Array<IProduct>;

  constructor(private productService: ProductService) {

  }

  ngOnInit() {
    this.products = this.productService.getProducts();
  }

  productWasAdded(product: IProduct): void {
    this.productService.addToCart(product);
  }
}
