import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';

//Sweetalert
import Swal from 'sweetalert2'

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent  {
  
  isDarkThemeActive = false;
  
  constructor(@Inject(DOCUMENT)private document: Document,
    private activedRouted: ActivatedRoute,
    private router: Router){
  }

 
  onChange(newValue: boolean){    
    console.log(newValue);
    if(newValue){
      this.document.body.classList.add('darkMode');      
    }
    else{
     this.document.body.classList.remove('darkMode');     
    }
  }

  usersForm(){
    this.router.navigate(['usersForm'])
  }

  usersList(){
    this.router.navigate(['usersList'])
  }

}
