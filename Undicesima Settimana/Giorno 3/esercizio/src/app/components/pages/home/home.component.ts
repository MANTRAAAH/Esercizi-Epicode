import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  get userName() {
    const accessData = this.authService.getAccessData();
    return accessData ? accessData.user.name : null;
  }
}
