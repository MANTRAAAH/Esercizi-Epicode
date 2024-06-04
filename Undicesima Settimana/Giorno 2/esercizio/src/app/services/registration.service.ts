
import { Injectable } from '@angular/core';
import { Registration } from '../interfaces/registration';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  register(user: Registration) {
    return of(user);
  }
}
