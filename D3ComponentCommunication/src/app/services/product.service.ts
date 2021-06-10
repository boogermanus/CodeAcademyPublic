import { Injectable } from '@angular/core';
import { IProduct } from '../interfaces/iproduct';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  products: IProduct[] = [];
  constructor() { }

  addProduct(product: IProduct) {
    this.products.push(product);
  }

  getProducts(): IProduct[] {
    return this.products;
  }
}
