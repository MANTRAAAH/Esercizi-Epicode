import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private authSvc: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const accessData = this.authSvc.getAccessData();

    if (!accessData) {
      return next.handle(req);
    }

    const authReq = req.clone({
      headers: req.headers.append('Authorization', `Bearer ${accessData.accessToken}`)
    });

    return next.handle(authReq);
  }
}
