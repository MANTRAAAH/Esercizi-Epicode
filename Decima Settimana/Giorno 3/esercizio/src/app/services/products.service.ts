import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private url = 'http://localhost:3000/products';

  constructor(private http: HttpClient) { }

  fetchProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.url);
  }
  private _favorites: Product[] = [];
  favorites = new BehaviorSubject<Product[]>([]);

  addToFavorites(product: Product) {
    this._favorites.push(product);
    this.favorites.next(this._favorites);
  }

}
