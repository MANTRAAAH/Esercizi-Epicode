import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { User } from '../../../models/user';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss'
})
export class SignupComponent {
  newUser: Partial<User> = {}
  constructor(
    private authService: AuthService
  ) { }
  signup(): void {
    this.authService.signup(this.newUser).subscribe()
  }
}
