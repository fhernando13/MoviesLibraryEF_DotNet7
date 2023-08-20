import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { UserService } from 'src/app/service/users/user.service';

//Sweetalert
import Swal from 'sweetalert2'

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent {

  selected = 'Employee';
  title = "Add information the user";
  button = "save";
  // _id: string|null;

  createFormGroup() {
    return new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]),
      lastname: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
      birthdate: new FormControl('', Validators.required),      
      email: new FormControl('', [Validators.required, Validators.minLength(5)]),
      password: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]), 
    });
  }
  
    userForm: FormGroup | any;

    constructor(private usersService: UserService,
      private router: Router,
      private activedRouted: ActivatedRoute){
      this.userForm = this.createFormGroup();
      // this._id = this.activedRouted.snapshot.paramMap.get('_id');
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

  ngOnInit(): void{    
  //this.isUpdate();
  }

  buttonSave(){
  console.log("ok");
  }
}
