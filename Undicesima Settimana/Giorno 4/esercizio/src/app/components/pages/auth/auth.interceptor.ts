import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable() export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) { }
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const accessData = this.authService.getAccessdata();
    if(!accessData) return next.handle(request);
    const newRequest=request.clone({
      headers:request.headers.append('Authorization',`Bearer ${accessData.accessToken}`)
  })
    return next.handle(newRequest);

}
}

