import { Component, OnInit} from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { UserService } from 'src/app/service/users/user.service';


@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent implements OnInit{

  selected = 'Employee';
  title = "Details the user";
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

  userDetail: FormGroup | any = {
    iduser: 0,
    name: '',
    lastname: '',
    birthdate: '',
    role: '',
    email: '',
    password: ''    
  };

  constructor(private userService: UserService,
    private router: Router,
    private activedRouted: ActivatedRoute){
    this.userDetail = this.createFormGroup();
    this.iduser = this.activedRouted.snapshot.paramMap.get('iduser');
}

get name() {
  return this.userDetail.get('name');
  }
  
  get lastname() {
  return this.userDetail.get('lastname');
  }
  
  get birthdate() {
  return this.userDetail.get('birthadte');
  }
  
  get role() {
    return this.userDetail.get(this.selected);
    }
  
  get email() {
  return this.userDetail.get('email');
  }

  get password() {
  return this.userDetail.get('password');
  }
    
  get password2() {
  return this.userDetail.get('password2');
  }

  ngOnInit(){     
    this.detailUser();   
  }
  
  detailUser(){
    const params = this.activedRouted.snapshot.params;
    console.log(params['iduser']);
    const data:any = this.userService.getUser(params['iduser'])
      .subscribe(
        {
          next: data=>(this.userDetail.setValue(            
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


}
