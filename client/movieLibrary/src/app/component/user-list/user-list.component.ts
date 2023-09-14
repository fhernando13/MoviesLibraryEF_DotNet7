import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../../service/users/user.service';
import { ActivatedRoute, Router } from '@angular/router';

// Angular Material
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

// Sweetalert
import Swal from 'sweetalert2'

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  users: any = [];

  title="list user"
  displayedColumns = ['ID','Name', 'Lastname', 'Email', 'Role','Options'];
  dataSource = new MatTableDataSource();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  constructor(
    public userService: UserService,
    private router: Router,
    private activatedRoute: ActivatedRoute){
  }

  ngOnInit(){
    this.listUsers();
  }

  async listUsers(){
    await this.userService.getUsers().subscribe({
     next: res =>{
       this.dataSource.data = res;
     },
     error: err =>{console.log(err)}}
   );
 }

  async askDelete(iduser:string){      
    Swal.fire({
      title: 'Do you want to delete the user?',
      showDenyButton: true,
      showCancelButton: false,
      confirmButtonText: 'Delete',
      denyButtonText: `Don't delete`,
    }).then((result) => {      
      if (result.isConfirmed) {
        this.userService.deleteUser(iduser).subscribe(
          {
            next: res =>{ this.users = res },
            error: err =>{console.log(err)},        
          }      
        );
        
        Swal.fire('Deleted!')      
      } else if (result.isDenied) {
        Swal.fire('User will not be deleted')
      }
      return this.listUsers();
    })
  }

}
