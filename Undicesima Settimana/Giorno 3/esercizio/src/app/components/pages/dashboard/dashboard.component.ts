import { User } from './../../../models/user';
import { Component } from '@angular/core';
import { AuthService } from '../../auth/auth.service';
import{Router} from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {
  user!: User;

  constructor(private authService: AuthService, private router: Router) {
  }

  ngOnInit() {
    this.authService.user$.subscribe(user => {
      if (user !== null) {
        this.user = user;
      }
    });
  }

  logout() {
     this.authService.logout()
    };
  }
