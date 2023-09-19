import { Component, OnInit} from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { UserService } from 'src/app/service/users/user.service';

//Sweetalert
import Swal from 'sweetalert2'


@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html',
  styleUrls: ['./user-update.component.scss']
})
export class UserUpdateComponent implements OnInit{

  selected = 'Employee';
  title = "Update data the user";
  button = "update";
  iduser: string|any;

  createFormGroup() {
    return new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]),
      lastname: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
      birthdate: new FormControl('', Validators.required),      
      role: new FormControl(this.selected, Validators.required),  
      email: new FormControl('', [Validators.required, Validators.minLength(5)]),                                  
    });  
  }

  userFormUpdate: FormGroup | any = {
    iduser: 0,
    name: '',
    lastname: '',
    birthdate: '',
    role: '',
    email: ''   
  };

  constructor(private userService: UserService,
    private router: Router,
    private activedRouted: ActivatedRoute){
    this.userFormUpdate = this.createFormGroup();
    this.iduser = this.activedRouted.snapshot.paramMap.get('iduser');
}

get name() {
  return this.userFormUpdate.get('name');
}
  
get lastname() {
  return this.userFormUpdate.get('lastname');
}
  
get birthdate() {
  return this.userFormUpdate.get('birthadte');
}
  
get role() {
  return this.userFormUpdate.get(this.selected);
}
  
get email() {
  return this.userFormUpdate.get('email');
}

  ngOnInit(){     
    this.updateUser();   
  }

  updateUser(){
    const params = this.activedRouted.snapshot.params;
    if(params['iduser'])
    {
      const data:any = this.userService.getUser(params['iduser'])
      .subscribe(
        {
          next: data=>(this.userFormUpdate.setValue(            
            {
              name: data.name,
              lastname: data.lastname,
              birthdate: data.birthdate,
              role: data.role,
              email: data.email
            }
          )),
          error: err=>(console.log(err)),
        }
      )
    }
    else
    {
      this.router.navigate(['/usersList']);
    }
        
  }

  buttonUpdate(){
    if(this.userFormUpdate){
      this.userService.updateUser(this.iduser, this.userFormUpdate.value).subscribe({
          next: res=>(this.userFormUpdate = res),
          error: err=>(console.log(err))
        }
      )
      this.router.navigate(['/users']);
      Swal.fire('Good job!', 'User saved!', 'success');
    }
    else{
      console.log('error');
    }    
    return this.router.navigate(['/usersList']);
  }

}
