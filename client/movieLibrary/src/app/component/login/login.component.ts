import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/service/login/login.service';

//Sweetalert
import Swal from 'sweetalert2'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private emailPattern: any =
  /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  
  title = "Add information the user";
  button = "save";

  createFormGroup() {
    return new FormGroup({      
      email: new FormControl('', [Validators.required, Validators.minLength(5), Validators.pattern(this.emailPattern)]),
      password: new FormControl('', Validators.required)
    });
  }

  loginForm: FormGroup | any;

  constructor(private loginService: LoginService,
              private router: Router)
    {
      this.loginForm = this.createFormGroup();
    }
  
    get email() {
      return this.loginForm.get('email');
    }
    get password() {
      return this.loginForm.get('password');
    }  

  ngOnInit(){    
  }

  Login(){
    if(this.loginForm.valid)
    {
      this.loginService.loginUser(this.loginForm.value).subscribe({
        next: (res) => {
          this.loginForm.value = res;          
          this.loginService.storeToken(res.token);
          const login = this.router.navigate(['/usersList']);
        },
        error: (err) => (
          console.log(err)
          )   
      }) 
    }
    else{
      Swal.fire({
        icon: 'error',
        title: 'Try again',
        text: 'User or password incorrect!'          
      })
    }   
    return this.Login;
  }

  changeType(){
    let elemento :any = document.getElementById('pass1');
    if(elemento.type == "password")
      {elemento.type = "text"}
      
    else{
      elemento.type = "password"
    }
  }

}

