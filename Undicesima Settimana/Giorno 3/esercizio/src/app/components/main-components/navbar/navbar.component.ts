import { Component } from '@angular/core';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  isLoggedIn: boolean = false;
  constructor(private authService: AuthService) { }
  ngOnInit() {
    this.authService.user$.subscribe(isLoggedIn => {
      this.isLoggedIn = Boolean(isLoggedIn) || false;
    })
  }
  logout() {
    this.authService.logout();
  }
}
