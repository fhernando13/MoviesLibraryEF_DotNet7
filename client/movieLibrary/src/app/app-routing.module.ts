import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Components
import { UserListComponent } from './component/user-list/user-list.component';
import { UserFormComponent } from './component/user-form/user-form.component';
import { UserDetailComponent } from './component/user-detail/user-detail.component';
import { UserUpdateComponent } from './component/user-update/user-update.component';
import { LoginComponent } from './component/login/login.component';


const routes: Routes = [
  { path: '', redirectTo: '/usersList', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'usersForm', component: UserFormComponent },
  { path: 'usersList', component: UserListComponent },
  { path: 'usersDetails/:iduser', component: UserDetailComponent },
  { path: 'usersUpdate/:iduser', component: UserUpdateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
