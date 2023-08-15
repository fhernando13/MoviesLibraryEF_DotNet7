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

  loginUser(login: Login){
    return this.http.post(this.API_URI,login);
  }
  
}
