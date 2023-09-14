import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../../models/users';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  API_URI ='http://localhost:5161/api/users';

  constructor(private http: HttpClient) 
  { 

  }
  getUsers(){
    return this.http.get<User[]>(this.API_URI+"/getall");    
  }

  saveUser(user: User){
    return this.http.post(this.API_URI+"/register",user);
  }

  deleteUser(id:string): Observable<any>{
    return this.http.delete(this.API_URI+"/delete/"+id)
    // return this.http.delete(this.API_URI+"/delete/"+Iduser);
  }

  getUser(id: string){
    return this.http.get(`${this.API_URI}/getone/${id}`);
  }
  
  updateUser(id: string, updateUser: User): Observable<any>{
    return this.http.put(this.API_URI+'/update/'+id, updateUser);
  }
}
