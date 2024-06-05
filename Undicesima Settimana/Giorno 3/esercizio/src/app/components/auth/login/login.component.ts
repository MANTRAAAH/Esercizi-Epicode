
import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { AuthData } from '../../../models/auth-data';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
AuthData: AuthData = {
    email: '',
    password: ''
  }
  constructor(
    private authService: AuthService,
    private router: Router
  ) { }
  login(): void {
    this.authService.login(this.AuthData).subscribe(
      () =>{this.router.navigate(['dashboard'])},
    )
}
}
