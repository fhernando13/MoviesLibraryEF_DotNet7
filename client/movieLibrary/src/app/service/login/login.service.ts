import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from '../../models/login';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  API_URI ='http://localhost:5161/api/autenthicate/login';

  constructor(private http: HttpClient) 
  { }

  loginUser(Login: any){
    return this.http.post<any>(this.API_URI, Login);
  }
  
  storeToken(tokenValue: string|any){
    localStorage.setItem('token', tokenValue);
  }

  getToken(){
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean{
    return !!localStorage.getItem('token');
  }

  removeToken(tokenValue: any){
    return localStorage.removeItem(tokenValue);
  }

}
