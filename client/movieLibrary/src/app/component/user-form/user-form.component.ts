import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { UserService } from 'src/app/service/users/user.service';
import { CustomValidators } from 'src/app/validators/customValidators';

//Sweetalert
import Swal from 'sweetalert2'

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  selected = 'Employee';
  title = "Add information the user";
  button = "save";
  iduser: string|null;
  

  createFormGroup() {
    return new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]),
      lastname: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
      birthdate: new FormControl('', Validators.required),      
      role: new FormControl(this.selected, Validators.required),  
      email: new FormControl('', [Validators.required, Validators.minLength(5)]),
      password: new FormControl('', [Validators.required, 
                                    // Validators.minLength(10), 
                                    // Validators.maxLength(10)//
                                  ]), 
      password2: new FormControl('', [Validators.required, 
        
              // Validators.minLength(10), 
              // Validators.maxLength(10)
            ]),                                  
    }, {
      validators: CustomValidators.mustBeEquals(
        'password',
        'password2'
      ),
    });    
  }

   
  
    userForm: FormGroup | any;

    constructor(private userService: UserService,
      private router: Router,
      private activedRouted: ActivatedRoute){
      this.userForm = this.createFormGroup();
      this.iduser = this.activedRouted.snapshot.paramMap.get('iduser');
}


get name() {
return this.userForm.get('name');
}

get lastname() {
return this.userForm.get('lastname');
}

get birthdate() {
return this.userForm.get('birthadte');
}

get role() {
  return this.userForm.get(this.selected);
  }

get email() {
return this.userForm.get('email');
}

get password() {
return this.userForm.get('password');
}

get password2() {
return this.userForm.get('password2');
}

  ngOnInit(): void{        
  }

  buttonSave(){    
    if (this.userForm) {      
      if(this.password.value === this.password2.value)
      {
        this.userService.saveUser(this.userForm.value).subscribe({
        next: (res) => (this.userForm = res),
        error: (err) => console.log(err),
        });            
        Swal.fire('Good job!', 'User saved!', 'success');
      }
      else
      {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Password are deferents!',          
        })
      }      
    } else {
      console.log('error');
    }
    return this.router.navigate(['/usersList']);
  }
    
}
