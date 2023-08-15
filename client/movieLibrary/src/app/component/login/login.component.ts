import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
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
      password: new FormControl('', [Validators.required])
    });
  }

  userForm: FormGroup | any;

  constructor(private loginService: LoginService,
              private router: Router,
              private activedRouted: ActivatedRoute)
    {
      this.userForm = this.createFormGroup();
    }
  
    get email() {
      return this.userForm.get('email');
    }
    get password() {
      return this.userForm.get('password');
    }  

  ngOnInit(): void{    
  }

  buttonSave(){
    if(this.userForm){
      console.log(this.userForm);
      this.loginService.loginUser(this.userForm.value).subscribe({
        next: res => this.userForm.value = res,
        error: (err) => console.log(err)
      })
    }else {
      console.log('error');
    }
    return this.router.navigate(['/users']);
}

}

