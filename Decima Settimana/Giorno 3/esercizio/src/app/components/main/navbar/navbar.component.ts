import { Component, TemplateRef, ViewChild } from '@angular/core';
import { CartService } from '../../../services/cart.service';
import { ProductsService } from '../../../services/products.service';
import { Product } from '../../../models/product';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  @ViewChild('cartModal') cartModal!: TemplateRef<any>;
  @ViewChild('favoritesModal') favoritesModal!: TemplateRef<any>;
  cart: Product[] = [];
  favorites: Product[] = [];

  constructor(
    public cartService: CartService,
    private productsService: ProductsService,
    private modalService: NgbModal
  ) {
    this.cartService.cart.subscribe(cart => {
      this.cart = cart;
    });
    this.productsService.favorites.subscribe(favorites => {
      this.favorites = favorites;
    });
  }

  openCart() {
    this.modalService.open(this.cartModal, { size: 'md' });
  }

  closeCart() {
    this.modalService.dismissAll();
  }

  openFavorites() {
    this.modalService.open(this.favoritesModal, { size: 'md' });
  }

  closeFavorites() {
    this.modalService.dismissAll();
  }
}
