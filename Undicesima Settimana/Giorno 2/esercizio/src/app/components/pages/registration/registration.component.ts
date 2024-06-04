import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { RegistrationService } from '../../../services/registration.service';
import { Registration } from '../../../interfaces/registration';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  registrationForm: any;

  constructor(private fb: FormBuilder, private registrationService: RegistrationService) {}

  ngOnInit() {
this.registrationForm = this.fb.group({
  nome: ['', [Validators.required, Validators.minLength(2)]],
  cognome: ['', [Validators.required, Validators.minLength(2)]],
  password: ['', [Validators.required, Validators.minLength(8)]],
  confermaPassword: ['', [Validators.required, Validators.minLength(8)]],
  genere: ['', Validators.required],
  biografia: ['', [Validators.required, Validators.maxLength(500)]],
  username: ['', [Validators.required, Validators.pattern(/^[a-zA-Z0-9_-]{8,20}$/)]],
});
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      const formValue = this.registrationForm.value as Registration;

      this.registrationService.register(formValue).subscribe({
        next: (response) => {
          let registrations = JSON.parse(localStorage.getItem('registrations') || '[]');
          registrations.push(formValue);
          localStorage.setItem('registrazioni', JSON.stringify(registrations));

          Swal.fire({
            title: 'Successo!',
            text: 'La registrazione è andata a buon fine.',
            icon: 'success',
            confirmButtonText: 'OK'
          });
        },
        error: (error) => {
          console.error('Si è verificato un errore durante la registrazione:', error);
        }
      });
    }
  }
}
