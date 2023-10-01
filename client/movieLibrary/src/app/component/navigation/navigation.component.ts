import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { LoginService } from 'src/app/service/login/login.service';


//Sweetalert
import Swal from 'sweetalert2'

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit  {
  
  isDarkThemeActive = this.statusBotton(false);
  
  constructor(
    @Inject(DOCUMENT)private document: Document,
    private loginService: LoginService,
    private activedRouted: ActivatedRoute,
    private router: Router){
  }

ngOnInit(): void {
   this.theme();
 }

statusBotton(themes: boolean){
  // const themes = localStorage.getItem('dark');
  if(localStorage.getItem('dark'))
  {
    return true
  }
  else{
    return false
  }
 }

 theme(){
  const dato = localStorage.getItem('dark');
  if(dato){
    this.onChange(true);
  }
  else{
    this.onChange(false);
  }
 }


  onChange(newValue: boolean){ 
    var dark = this.document.body.classList.add('darkMode');
    console.log(newValue);
    if(newValue){
      localStorage.setItem('dark', JSON.stringify(dark));
    }
    else{
      localStorage.removeItem('dark');
      this.document.body.classList.remove('darkMode');     
    }
  }

  usersForm(){
    this.router.navigate(['usersForm'])
  }

  usersList(){
    this.router.navigate(['usersList'])
  }


  
  logOut(){
    localStorage.removeItem('dark');
    this.onChange(false);
    this.loginService.removeToken('token');
    this.router.navigate(["/login"]);
  }

}
