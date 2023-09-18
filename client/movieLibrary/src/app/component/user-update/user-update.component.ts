import { Component, OnInit} from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { UserService } from 'src/app/service/users/user.service';

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

  userUpdate: FormGroup | any = {
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
    this.userUpdate = this.createFormGroup();
    this.iduser = this.activedRouted.snapshot.paramMap.get('iduser');
}

get name() {
  return this.userUpdate.get('name');
}
  
get lastname() {
  return this.userUpdate.get('lastname');
}
  
get birthdate() {
  return this.userUpdate.get('birthadte');
}
  
get role() {
  return this.userUpdate.get(this.selected);
}
  
get email() {
  return this.userUpdate.get('email');
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
          next: data=>(this.userUpdate.setValue(            
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

  }

}
