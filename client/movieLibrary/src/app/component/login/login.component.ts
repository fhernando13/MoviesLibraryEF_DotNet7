import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/service/login/login.service';
import { UserAppService } from 'src/app/service/user-app/user-app.service';

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
  viewPass = '';

  createFormGroup() {
    return new FormGroup({      
      email: new FormControl('', [Validators.required, Validators.minLength(5), Validators.pattern(this.emailPattern)]),
      password: new FormControl('', Validators.required)
    });
  }

  loginForm: FormGroup | any;
  passWD = 'visibility';

  constructor(private loginService: LoginService,
              private userApp: UserAppService,
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
          const tokenPayLoad = this.loginService.decodedToken()
          this.userApp.setNicknameFromApi(tokenPayLoad.unique_name);
          this.userApp.setRoleFromApi(tokenPayLoad.role);
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
    let showPassword :any = document.getElementById('pass1');
    if(showPassword.type == "password")
      {showPassword.type = "text";
      this.passWD = 'visibility_off';
      this.viewPass = 'hide the password';
    }            
    else{
      showPassword.type = "password";
      this.passWD = 'visibility';
      this.viewPass = 'show the password';
    }
  }

}

