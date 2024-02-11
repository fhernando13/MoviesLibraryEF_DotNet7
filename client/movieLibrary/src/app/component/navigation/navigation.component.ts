import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/service/login/login.service';
import { UserAppService } from 'src/app/service/user-app/user-app.service';


//Sweetalert
import Swal from 'sweetalert2'

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit  {
  
  isDarkThemeActive = this.statusBotton(false);
  public unique_name : string = "";
  public role : string = "";
  icon = '';
  themes = '';
  click = true;
  mode = ''

  constructor(
    @Inject(DOCUMENT)private document: Document,
    private loginService: LoginService,
    private userApp: UserAppService,
    private router: Router){
  }

ngOnInit(){
   this.theme();
   this.getNickname();
   this.getRole();
 }

statusBotton(themes: boolean){
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
    if(newValue){
      localStorage.setItem('dark', JSON.stringify(dark));
      this.icon = 'brightness_2';
      this.mode = 'ON'
    }
    else{
      localStorage.removeItem('dark');
      this.document.body.classList.remove('darkMode');   
      this.icon = 'brightness_5';
      this.mode = 'OFF';
    }
  }

  
  usersForm(){
    this.router.navigate(['usersForm'])
  }

  usersList(){
    this.router.navigate(['usersList'])
  }

  actorForm(){
    this.router.navigate(['actors'])
  }

  genderForm(){
    this.router.navigate(['genders'])
  }

  moviesForm(){
    this.router.navigate(['movies'])
  }

  logOut(): void{    
    try{
      localStorage.removeItem('dark');
      this.onChange(false);
      this.loginService.removeToken('token');
      localStorage.clear();
      this.router.navigate(["/login"]);
    }
    catch(error){
      console.log(error);
    }
  }

  getNickname(){
    this.userApp.getNicknameFromApi()
    .subscribe(val=>{
      const fullNameFromToken = this.loginService.getNicknameFromToken();
      this.unique_name = val || fullNameFromToken;
      console.log(this.unique_name)
    })
  }

  getRole(){
    this.userApp.getRoleFromApi()
    .subscribe(val2=>{
      const fullRolFromToken = this.loginService.getRoleFromToken()
      this.role = val2 || fullRolFromToken;
      console.log(this.role)
    })
  }

 

}
