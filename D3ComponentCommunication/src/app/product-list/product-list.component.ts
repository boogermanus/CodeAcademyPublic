import { Component, OnInit } from '@angular/core';
import { IProduct } from '../interfaces/iproduct';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: Array<IProduct> = [];
  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.products = this.productService.getProducts();
  }

  productAdded(product: IProduct) {
    this.products.push(product);
  }
}
