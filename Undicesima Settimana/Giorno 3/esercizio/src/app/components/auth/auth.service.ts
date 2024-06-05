import { AuthData } from './../../models/auth-data';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import {JwtHelperService} from '@auth0/angular-jwt';
import {BehaviorSubject,Observable,map,tap} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {User} from '../../models/user';
import {AuthResponse} from '../../models/auth-response';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  jwtHelper: JwtHelperService = new JwtHelperService()
  UserSubject= new BehaviorSubject<null|User>(null);
  syncIsLoggedIn:boolean = false;
  user$ = this.UserSubject.asObservable();
  isLoggedIn$ = this.user$.pipe(map(user=>!!user),
  tap(user=>this.syncIsLoggedIn = user));

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }
  loginUrl:string ='http://localhost:3000/login';
  signupUrl:string ='http://localhost:3000/signup';

  signup(newUser:Partial<User>):Observable<AuthResponse>{
    return this.http.post<AuthResponse>(this.signupUrl,newUser)
  }

  login(AuthData:AuthData):Observable<AuthResponse>{
    return this.http.post<AuthResponse>(this.loginUrl,AuthData).pipe(
      tap((res:AuthResponse)=>{
        localStorage.setItem('accessData',JSON.stringify(res));
        this.UserSubject.next(res.user);
      })
    )
  }

  logout():void{
    localStorage.removeItem('accessData');
    this.UserSubject.next(null);
    this.router.navigate(['/auth']);
  }
  autoLogout(){
    const accessData = this.getAccessData();
    if(!accessData) return;
    const expDate = this.jwtHelper.getTokenExpirationDate(accessData.accessToken) as Date;
    const now = new Date();
    const expiresIn = expDate.getTime() - now.getTime();
  setTimeout(this.logout,expiresIn);}

getAccessData(): AuthResponse | null {
    const accessDataJson = localStorage.getItem('accessData');
    if (!accessDataJson) return null;

    const accessData: AuthResponse = JSON.parse(accessDataJson);
    this.UserSubject.next(accessData.user);

    return accessData;
}
restoreUser():void{
  const accessData = this.getAccessData();
  if(!accessData) return
  if (this.jwtHelper.isTokenExpired(accessData.accessToken)) return;
  this.UserSubject.next(accessData.user);
  this.autoLogout();
}
}
