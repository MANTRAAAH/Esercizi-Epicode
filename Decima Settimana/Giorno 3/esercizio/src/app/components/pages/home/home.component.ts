import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductsService } from '../../../services/products.service';
import { Product } from '../../../models/product';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CartService } from '../../../services/cart.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  products: Product[] = [];
  cart: Product[] = [];

  @ViewChild('cartModal') cartModal: any;

  constructor(private productsService: ProductsService,private cartService: CartService) { }

  ngOnInit() {
    this.productsService.fetchProducts().subscribe(data => {
      this.products = data;
    });
  }
  addToFavorites(product: Product) {
    this.productsService.addToFavorites(product);
  }

  addToCart(product: Product) {
    this.cartService.addToCart(product);
  }


}
