import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Components
import { UserListComponent } from './component/user-list/user-list.component';
import { UserFormComponent } from './component/user-form/user-form.component';
import { LoginComponent } from './component/login/login.component';

const routes: Routes = [
  { path: '', redirectTo: '/usersList', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'usersForm', component: UserFormComponent },
  { path: 'usersList', component: UserListComponent },
  { path: 'usersFormUpdate/:iduser', component: UserFormComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
