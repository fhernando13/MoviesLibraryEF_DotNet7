import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  API_URI ='http://localhost:5161/api/autenthicate/login';
  private userPayload:any;
  
  constructor(private http: HttpClient) 
  { 
    this.userPayload = this.decodedToken();
  }

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

  decodedToken(){
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    console.log(jwtHelper.decodeToken(token))
    return jwtHelper.decodeToken(token)
  }
  
  getNicknameFromToken(){
    if(this.userPayload)
    return this.userPayload.unique_name;
  }

  getRoleFromToken(){
    if(this.userPayload)
    return this.userPayload.role;
  }

}
