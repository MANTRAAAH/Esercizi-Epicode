
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  username = '';
  password = '';

  users = [
    { username: 'user1', password: 'pass1' },
    { username: 'user2', password: 'pass2' },
    { username: 'admin', password: 'admin' },
  ];

  onSubmit(form: NgForm) {
    if (form.valid) {
      const user = this.users.find(user => user.username === this.username && user.password === this.password);
      if (user) {
        Swal.fire({
          title: 'Successo!',
          text: 'Il login è andato a buon fine.',
          icon: 'success',
          confirmButtonText: 'OK'
        });
      } else {
        Swal.fire({
          title: 'Errore!',
          text: 'Username o password non validi.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    }
  }
}
