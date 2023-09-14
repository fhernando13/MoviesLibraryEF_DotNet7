import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { UserService } from 'src/app/service/users/user.service';

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
      email: new FormControl('', [Validators.required, Validators.minLength(5)]),
      password: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]), 
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

  ngOnInit(): void{    
    this.isUpdate();
  }

  isUpdate(){    
    if(this.iduser){
      // const params = this.activedRouted.snapshot.params;
      this.title = "Update user";
      this.button = "Update"
      const data = this.userService.getUser(this.iduser)
      .subscribe(
        {
          next: data=>(console.log(data)),
          error: err=>(alert(err))
        }
      )
    }
  }

  buttonSave(){
    if(this.iduser !== null){
      this.userService.updateUser(this.iduser, this.userForm.value).subscribe({
        next: data =>(this.userForm = data),
        error: err => console.log(err),
      });
      Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'User has been updated',
        showConfirmButton: false,
        timer: 1500
      })    
    }else{
      //create user
    if(this.userForm){
      console.log(this.userForm);
      this.userService.saveUser(this.userForm.value).subscribe({
        next: res => this.userForm.value = res,
        error: (err) => console.log(err)
      })
      Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Your work has been saved',
        showConfirmButton: false,
        timer: 1500
      })      
    }else {
      console.log('error');
    }
    }//back to home
    return this.router.navigate(['/users']);
  }

}
