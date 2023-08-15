import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent  {
  
  isDarkThemeActive = false;
  
  constructor(@Inject(DOCUMENT)private document: Document){
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

}
