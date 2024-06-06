import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject,Observable,map,tap } from 'rxjs';
import { User } from './models/user';
import { HttpClient } from '@angular/common/http';
import { AuthData } from './models/auth-data';
import { AuthResponse } from './models/auth-response';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  jwtHelper: JwtHelperService = new JwtHelperService();
  authSubject = new BehaviorSubject<null|User>(null);
  syncIsLoggedin:boolean=false;
  user$=this.authSubject.asObservable();
  isLoggedIn=this.authSubject.pipe(map(user=>!!user),
  tap(user=>this.syncIsLoggedin= user));



  constructor(private http:HttpClient,private router:Router) {

    this.restoreUser();


  }
  loginUrl:string='http://localhost:3000/login';
  registerUrl:string='http://localhost:3000/register';

  register(newUser:Partial<User>):Observable<AuthResponse>{
    return this.http.post<AuthResponse>(this.registerUrl,newUser)
  }

  login(AuthData:AuthData):Observable<AuthResponse>{
    return this.http.post<AuthResponse>(this.loginUrl,AuthData).pipe(
      tap(data=>{
        this.authSubject.next(data.user)
        localStorage.setItem('accessData',JSON.stringify(data))
        this.autoLogOut()
      })
    )
  }



  logout():void{
    this.authSubject.next(null);
    localStorage.removeItem('accessData');
    this.router.navigate(['/auth'])
  }




  autoLogOut():void{
    const accessData=this.getAccessdata();
    if(!accessData) return;
    const expiresIn=this.jwtHelper.getTokenExpirationDate(accessData.accessToken) as Date
    const expMs= expiresIn.getTime()-new Date().getTime();
    setTimeout(this.logout,expMs)

  }


  getAccessdata():AuthResponse|null{
    const accessDataJson=localStorage.getItem('accessData');
    if(!accessDataJson) return null

    const accessData:AuthResponse=JSON.parse(accessDataJson);
    return accessData;
  }


  restoreUser():void{
    const accessData=this.getAccessdata();
    if(!accessData) return;
    if(this.jwtHelper.isTokenExpired(accessData.accessToken)) return
    this.authSubject.next(accessData.user);
    this.autoLogOut();


  }
}
