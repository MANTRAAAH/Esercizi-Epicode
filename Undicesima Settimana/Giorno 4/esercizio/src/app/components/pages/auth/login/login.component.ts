import { AuthData } from './../models/auth-data';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  AuthData: AuthData = {
    email: '',
    password: ''
  };

  constructor(private authService: AuthService, private router: Router) { }
  login(){
    this.authService.login(this.AuthData).subscribe(()=>{
      this.router.navigate(['/dashboard']);
    })
    };
  }

