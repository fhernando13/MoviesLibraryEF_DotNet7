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

  ngOnInit(): void{    
  }

  Login(){
    if(this.loginForm.valid)
      console.log(this.loginForm.value);
      this.loginService.loginUser(this.loginForm.value).subscribe({
        next: (res) => {
          console.log(res.message);
          this.loginForm.value = res;          
          this.loginService.storeToken(res.token);
        },
        error: (err) => (Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Something went wrong!'          
        }),
        this.router.navigate(["/login"]))   
      })    
    return this.router.navigate(['/usersList']);
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

