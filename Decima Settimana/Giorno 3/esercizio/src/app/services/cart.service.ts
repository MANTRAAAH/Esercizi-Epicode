import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private _cart: Product[] = [];
  cart = new BehaviorSubject<Product[]>([]);
  total = new BehaviorSubject<number>(0);

  addToCart(product: Product) {
    this._cart.push(product);
    this.cart.next(this._cart);
    this.calculateTotal();
  }

  getCart() {
    return this._cart;
  }

  private calculateTotal() {
    let total = 0;
    for (let product of this._cart) {
      total += product.price;
    }
    this.total.next(total);
  }
}
